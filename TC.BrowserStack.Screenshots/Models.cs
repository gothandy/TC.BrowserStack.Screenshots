using System.Runtime.Serialization;

namespace TC.BrowserStack.Screenshots
{
    [DataContract]
    [KnownType(typeof(SettingsModel))]
    [KnownType(typeof(JobModel[]))]
    [KnownType(typeof(JobModel))]
    public class ConfigModel
    {
        [DataMember(Order = 1)]
        public SettingsModel settings { get; set; }

        [DataMember(Order = 2)]
        public JobModel[] jobs { get; set; }

        [DataMember(Order = 3)]
        public JobModel job_defaults { get; set; }
    }

    [DataContract]
    public class SettingsModel
    {

        [DataMember(Order = 1)]
        public string username { get; set; }

        [DataMember(Order = 2)]
        public string password { get; set; }

        [DataMember(Order = 3)]
        public string output { get; set; }

        [DataMember(Order = 4)]
        public string rooturl { get; set; }

        [DataMember(Order = 5)]
        public int retry_attempts { get; set; }

        [DataMember(Order = 6)]
        public int retry_wait_minutes { get; set; }
    }

    [DataContract]
    [KnownType(typeof(BrowserModel[]))]
    public class JobModel
    {

        [DataMember(Order = 1)]
        public string url { get; set; }

        [DataMember(Order = 2)]
        public string win_res { get; set; }

        [DataMember(Order = 3)]
        public string mac_res { get; set; }

        [DataMember(Order = 4)]
        public string quality { get; set; }

        [DataMember(Order = 5)]
        public int wait_time { get; set; }

        [DataMember(Order = 6)]
        public string orientation { get; set; }

        [DataMember(Order = 7)]
        public BrowserModel[] browsers { get; set; }
    }

    [DataContract]
    public class BrowserModel
    {

        [DataMember(Order = 1)]
        public string device { get; set; } // null, Samsung Galaxy S3 etc.

        [DataMember(Order = 2)]
        public string os { get; set; } //Windows, OS X, android etc.

        [DataMember(Order = 3)]
        public string os_version { get; set; } // 8, 9 etc.

        [DataMember(Order = 4)]
        public string browser { get; set; } // ie, opera etc.

        [DataMember(Order = 5)]
        public string browser_version { get; set; } // 10.0 Desktop, 6.0 etc.
    }

    [DataContract]
    [KnownType(typeof(JobLogModel[]))]
    public class RunLogModel
    {

        [DataMember(Order = 1)]
        public JobLogModel[] jobLogs { get; set; }
    }

    [DataContract]
    [KnownType(typeof(ScreenShotModel[]))]
    public class JobLogModel
    {

        [DataMember(Order = 1)]
        public string job_id { get; set; } //578308ad98e0764c853bd41d4ccacc7826892944"

        [DataMember(Order = 2)]
        public string quality { get; set; } //compressed

        [DataMember(Order = 3)]
        public int wait_time { get; set; } //5

        [DataMember(Order = 4)]
        public string win_res { get; set; } //1280x1024"

        [DataMember(Order = 5)]
        public string mac_res { get; set; } //1920x1080"

        [DataMember(Order = 6)]
        public string callback_url { get; set; }

        [DataMember(Order = 7)]
        public ScreenShotModel[] screenshots { get; set; }
    }

    [DataContract]
    public class ScreenShotModel
    {

        [DataMember(Order = 1)]
        public string id { get; set; } //8f4ea390230e7ece787347fa16b0546c6e60615f

        [DataMember(Order = 2)]
        public string state { get; set; } //pending

        [DataMember(Order = 3)]
        public string url { get; set; } //http://tc-website-ui-html.azurewebsites.net/Pages/Home

        [DataMember(Order = 4)]
        public string device { get; set; }

        [DataMember(Order = 5)]
        public string os { get; set; } //Windows

        [DataMember(Order = 6)]
        public string os_version { get; set; } //8

        [DataMember(Order = 7)]
        public string browser { get; set; } //ie

        [DataMember(Order = 8)]
        public string browser_version { get; set; } //10.0 Desktop

        [DataMember(Order = 9)]
        public string thumb_url { get; set; }

        [DataMember(Order = 10)]
        public string image_url { get; set; }

        [DataMember(Order = 11)]
        public string created_at { get; set; }
    }

    [DataContract]
    public class MessageModel
    {

        [DataMember(Order = 1)]
        public string message { get; set; }
    }
}

