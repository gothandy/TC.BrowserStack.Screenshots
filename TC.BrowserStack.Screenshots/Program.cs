using System.IO;

namespace TC.BrowserStack.Screenshots
{
    // Example command line arguments:
    //
    // brwosers
    // images 2014-10-31-22-14.json
    // jobs TC.Website.UI.Html.BrowserStack.json

    class Program
    {
        static void Main(string[] args)
        {
            switch (args[0])
            {
                case "browsers":

                    Browsers.DownloadAndWrite();
                    break;

                case "jobs":

                    ConfigModel configModel = JsonFile.ReadObject<ConfigModel>(args[1]);
                    Jobs jobs = new Jobs(configModel);
                    jobs.Run();
                    break;

                case "images":
                    RunLogModel runLog = JsonFile.ReadObject<RunLogModel>(args[1]);
                    Images images = new Images(runLog, Path.GetFileNameWithoutExtension(args[1]));
                    images.Download();
                    break;
            }
        }


    }
}
