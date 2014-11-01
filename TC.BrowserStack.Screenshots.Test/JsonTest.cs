using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TC.BrowserStack.Screenshots.Test
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void SerializeMessage()
        {
            MessageModel value = new MessageModel();

            value.message = "test";

            string result = Json.Serialize<MessageModel>(value);

            Assert.IsTrue(result.Contains(value.message));
        }

        [TestMethod]
        public void SerializeJob1()
        {
            JobModel value = new JobModel();
            BrowserModel b1 = new BrowserModel();

            value.browsers = new BrowserModel[1] { b1 };

            string result = Json.Serialize<JobModel>(value);

            Assert.IsTrue(result.Contains("browsers"));
        }

        [TestMethod]
        public void SerializeJob2()
        {
            JobModel value = new JobModel();
            BrowserModel b1 = new BrowserModel();
            BrowserModel b2 = new BrowserModel();

            value.browsers = new BrowserModel[2] { b1, b2 };

            string result = Json.Serialize<JobModel>(value);

            Assert.IsTrue(result.Contains("browsers"));
        }

        [TestMethod]
        public void SerializeJobLog()
        {
            JobLogModel value = new JobLogModel();
            ScreenShotModel ss1 = new ScreenShotModel();

            ss1.id = "aaaa";

            value.screenshots = new ScreenShotModel[1] { ss1 };

            string result = Json.Serialize<JobLogModel>(value);

            Assert.IsTrue(result.Contains("aaaa"));
        }
    }
}
