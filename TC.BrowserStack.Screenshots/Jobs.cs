using System;
using System.Collections.Generic;
using System.Net;
using System.Threading;

namespace TC.BrowserStack.Screenshots
{
    public class Jobs
    {
        private ConfigModel config;

        public Jobs(ConfigModel config)
        {
            this.config = config;
        }

        public void Run()
        {
            List<JobLogModel> jobLogs = new List<JobLogModel>();
            

            foreach (var job in config.jobs)
            {
                config.job_defaults.url = config.settings.rooturl + job.url;

                Console.WriteLine(job.url);

                JobLogModel jobLog = generateScreenshots(config.job_defaults);

                if (jobLog != null)
                {
                    jobLogs.Add(jobLog);
                }
            }

            writeRunLog(jobLogs);
        }

        private static void writeRunLog(List<JobLogModel> jobLogs)
        {
            string path = String.Format(DateTime.UtcNow.ToString("yyyy-MM-dd-HH-mm") + ".json");

            RunLogModel runLog = new RunLogModel();
            runLog.jobLogs = jobLogs.ToArray();

            Console.WriteLine(path);

            JsonFile.WriteObject(runLog, path);
        }

        private JobLogModel generateScreenshots(JobModel job)
        {
            JobLogModel jobLog = null;
            bool retry = true;
            int retryCount = 0;
            

            while (retry && retryCount < config.settings.retry_attempts)
            {
                
                try
                {
                    jobLog = JsonWeb.UploadObject<JobLogModel, JobModel>(job, "http://www.browserstack.com/screenshots", config.settings.username, config.settings.password);
                    retry = false;
                }
                catch (WebException e)
                {
                    if (e.Response.ContentType == "application/json; charset=utf-8")
                    {
                        retryCount++;
                        string message = readMessage(e.Response);
                        Console.Write("{0} {1}.", e.Message, message);

                        if (message != "Parallel limit reached")
                        {
                            retry = false;
                            Console.WriteLine(" No Retry.");
                        }
                        else
                        {
                            Console.Write(" Retry {0}.", retryCount);

                            if (retryCount < config.settings.retry_attempts)
                            {
                                Console.WriteLine(" Wait {0} minutes.", config.settings.retry_wait_minutes);
                                Thread.Sleep(config.settings.retry_wait_minutes * 60 * 1000);
                            }
                            else
                            {
                                Console.WriteLine(" Retry attempt limit reached.");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(e.Message);
                        retry = false;
                    }
                }
            }

            return jobLog;

        }

        private string readMessage(WebResponse webResponse)
        {
            MessageModel response = JsonFile.ReadObject<MessageModel>(webResponse.GetResponseStream());

            return response.message;
        }
    }
}
