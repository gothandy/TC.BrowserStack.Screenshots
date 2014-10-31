using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading;

namespace TC.BrowserStack.Screenshots
{
    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "browsers":

                    Browsers browsers = new Browsers();
                    browsers.Download();
                    browsers.Write();
                    break;

                case "jobs":

                    ConfigModel configModel = deserialize<ConfigModel>(args[1]);
                    Jobs jobs = new Jobs(configModel);
                    jobs.Run();
                    break;

                case "images":
                    RunLogModel runLog = deserialize<RunLogModel>(args[1]);
                    Images images = new Images(runLog, Path.GetFileNameWithoutExtension(args[1]));
                    images.Download();
                    break;
            }
        }

        private static T1 deserialize<T1>(string path)
        {
            string fullPath = Path.GetFullPath(path);
            string json = File.ReadAllText(fullPath);

            T1 obj = JsonConvert.DeserializeObject<T1>(json);

            return obj;
        }
    }
}
