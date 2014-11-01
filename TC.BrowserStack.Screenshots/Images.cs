using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TC.BrowserStack.Screenshots
{
    public class Images
    {
        private RunLogModel runLog;
        private string folderName;

        public Images(RunLogModel runLog, string runLogFileName)
        {
            this.runLog = runLog;
            this.folderName = Path.GetFileNameWithoutExtension(runLogFileName);
        }

        public void Download()
        {
            Directory.CreateDirectory(folderName);

            foreach(JobLogModel job in runLog.jobLogs)
            {
                Console.WriteLine(removeDomain(job.screenshots[0].url));
                waitForAllDone(job.job_id);
                downloadImages(job.job_id);
            }
        }

        private void waitForAllDone(string id)
        {
            while (checkForAllDone(id))
            {
                Console.Write(".");
                Thread.Sleep(10000);
            }

            Console.WriteLine("All Done");
        }

        private bool checkForAllDone(string id)
        {
            bool notDone = false;

            JobLogModel job = getJob(id);

            foreach (var screenshot in job.screenshots)
            {
                if (screenshot.state != "done" && screenshot.state != "timed-out") notDone = true;
            }
            return notDone;
        }

        private JobLogModel getJob(string id)
        {
            string url = String.Format("http://www.browserstack.com/screenshots/{0}.json", id);

            return JsonWeb.DownloadObject<JobLogModel>(url);
        }

        private void downloadImages(string id)
        {
            JobLogModel job = getJob(id);

            foreach (var screenshot in job.screenshots)
            {
                if (screenshot.image_url != null)
                {
                    string page = cleanUrl(screenshot.url.ToString());

                    //downloadImage(page, screenshot.thumb_url.ToString());
                    downloadImage(page, screenshot.image_url.ToString());
                }
            }
        }

        private void downloadImage(string page, string url)
        {
            if (!String.IsNullOrEmpty(url))
            {
                Console.WriteLine(url);
                string fullPath = String.Format("{0}\\{1}-{2}",
                    folderName, page, Path.GetFileName(url));

                using (var web = new WebClient())
                {
                    web.DownloadFile(url, fullPath);
                }
            }
        }

        private string cleanUrl(string url)
        {
            
            url = removeDomain(url);
            url = url.Replace("/", "-");

            return url;
        }

        private static string removeDomain(string url)
        {
            url = url.Replace("http://", "");
            int a = url.IndexOf("/");
            url = url.Substring(a+1);
            return url;
        }
    }
}
