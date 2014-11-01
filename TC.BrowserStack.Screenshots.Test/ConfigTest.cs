using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TC.BrowserStack.Screenshots.Test
{
    [TestClass]
    public class ConfigTest
    {
        [TestMethod]
        public void SerializeJob()
        {
            ConfigModel config = JsonFile.ReadObject<ConfigModel>("..\\..\\Test_Data\\TC.Website.UI.Html.BrowserStack.json");

            config.job_defaults.url = "http://tc-website-ui-html.azurewebsites.net/Pages/Home";

            string result = Json.Serialize<JobModel>(config.job_defaults);

            Assert.IsTrue(result.Contains("azurewebsites"));
        }

    }
}
