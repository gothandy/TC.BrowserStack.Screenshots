using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace TC.BrowserStack.Screenshots.Test
{
    [TestClass]
    public class ProgramTest
    {
        private string originalDirectory;
        [TestInitialize]
        public void Initialize()
        {
            originalDirectory = Directory.GetCurrentDirectory();
            Directory.SetCurrentDirectory("..\\..\\Test_Data");
            Directory.CreateDirectory("ProgramTest");
            Directory.SetCurrentDirectory("ProgramTest");
        }

        [TestMethod]
        public void BrowserTest()
        {
            Browsers.DownloadAndWrite();
            Assert.IsTrue(File.Exists("browsers.json"));
        }

        [TestMethod]
        public void JobsTest()
        {
            ConfigModel configModel = JsonFile.ReadObject<ConfigModel>("..\\one.json");
            Jobs jobs = new Jobs(configModel);
            string path = jobs.Run();
            Assert.IsTrue(File.Exists(path));
            Assert.AreNotEqual("{\"jobLogs\":[]}", File.ReadAllText(path));
        }

        [TestMethod]
        public void ImagesTest()
        {
            RunLogModel runLog = JsonFile.ReadObject<RunLogModel>("..//2014-11-01-17-00.json");
            Images images = new Images(runLog, "2014-11-01-17-00.json");
            images.Download();

            Assert.IsTrue(File.Exists("2014-11-01-17-00\\doodles-win8_ie_10.0_Desktop.jpg"));
        }

        [TestCleanup]
        public void CleanUp()
        {
            Directory.SetCurrentDirectory("..\\");
            Directory.Delete("ProgramTest", true);
            Directory.SetCurrentDirectory(originalDirectory);
        }
    }
}
