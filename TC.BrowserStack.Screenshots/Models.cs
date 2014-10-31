using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TC.BrowserStack.Screenshots
{
    public class ConfigModel
    {
        public SettingsModel settings { get; set; }
        public JobModel[] jobs { get; set; }
        public JobModel job_defaults { get; set; }
    }

    public class SettingsModel
    {
        public string username { get; set; }
        public string password { get; set; }
        public string output { get; set; }
        public string rooturl { get; set; }
        public int retry_attempts { get; set; }
        public int retry_wait_minutes { get; set; }
    }

    public class JobModel
    {
        public string url { get; set; }
        public string win_res { get; set; }
        public string mac_res { get; set; }
        public string quality { get; set; }
        public int wait_time { get; set; }
        public string orientation { get; set; }
        public BrowserModel[] browsers { get; set; }
    }

    public class BrowserModel
    {
        public string device { get; set; } // null, Samsung Galaxy S3 etc.
        public string os { get; set; } //Windows, OS X, android etc.
        public string os_version { get; set; } // 8, 9 etc.
        public string browser { get; set; } // ie, opera etc.
        public string browser_version { get; set; } // 10.0 Desktop, 6.0 etc.
    }

    public class RunLogModel
    {
        public JobLogModel[] jobLogs { get; set; }
    }

    public class JobLogModel
    {
        public string job_id { get; set; } //578308ad98e0764c853bd41d4ccacc7826892944"
        public string quality { get; set; } //compressed
        public int wait_time { get; set; } //5
        public string win_res { get; set; } //1280x1024"
        public string mac_res { get; set; } //1920x1080"
        public string callback_url { get; set; }
        public ScreenShotModel[] screenshots { get; set; }
    }

    public class ScreenShotModel
    {
        public string id { get; set; } //8f4ea390230e7ece787347fa16b0546c6e60615f
        public string state { get; set; } //pending
        public string url { get; set; } //http://tc-website-ui-html.azurewebsites.net/Pages/Home
        public string device { get; set; }
        public string os { get; set; } //Windows
        public string os_version { get; set; } //8
        public string browser { get; set; } //ie
        public string browser_version { get; set; } //10.0 Desktop
        public string thumb_url { get; set; }
        public string image_url { get; set; }
        public string created_at { get; set; }
    }
}

