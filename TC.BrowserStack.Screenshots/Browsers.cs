using System.IO;
namespace TC.BrowserStack.Screenshots
{
    public class Browsers
    {
        const string browsersJson = "http://www.browserstack.com/screenshots/browsers.json";

        public static void DownloadAndWrite()
        {
            BrowserModel[] browsers;

            browsers = JsonWeb.DownloadObject<BrowserModel[]>(browsersJson);

            JsonFile.WriteObject(browsers, Path.GetFileName(browsersJson));
        }
    }
}
