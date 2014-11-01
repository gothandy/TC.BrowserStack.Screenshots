using System.Runtime.Serialization;

namespace TC.BrowserStack.Screenshots
{
    [DataContract]
    [KnownType(typeof(SettingsModel))]
    [KnownType(typeof(JobModel[]))]
    [KnownType(typeof(JobModel))]
    public class ConfigModel
    {
        [DataMember]
        public SettingsModel settings { get; set; }

        [DataMember]
        public JobModel[] jobs { get; set; }

        [DataMember]
        public JobModel job_defaults { get; set; }
    }

    [DataContract]
    public class SettingsModel
    {

        [DataMember]
        public string username { get; set; }

        [DataMember]
        public string password { get; set; }

        [DataMember]
        public string output { get; set; }

        [DataMember]
        public string rooturl { get; set; }

        [DataMember]
        public int retry_attempts { get; set; }

        [DataMember]
        public int retry_wait_minutes { get; set; }
    }

    [DataContract]
    [KnownType(typeof(BrowserModel[]))]
    public class JobModel
    {

        [DataMember]
        public string url { get; set; }

        [DataMember]
        public string win_res { get; set; }

        [DataMember]
        public string mac_res { get; set; }

        [DataMember]
        public string quality { get; set; }

        [DataMember]
        public int wait_time { get; set; }

        [DataMember]
        public string orientation { get; set; }

        [DataMember]
        public BrowserModel[] browsers { get; set; }
    }

    [DataContract]
    public class BrowserModel
    {

        [DataMember]
        public string device { get; set; } // null, Samsung Galaxy S3 etc.

        [DataMember]
        public string os { get; set; } //Windows, OS X, android etc.

        [DataMember]
        public string os_version { get; set; } // 8, 9 etc.

        [DataMember]
        public string browser { get; set; } // ie, opera etc.

        [DataMember]
        public string browser_version { get; set; } // 10.0 Desktop, 6.0 etc.
    }

    [DataContract]
    [KnownType(typeof(JobLogModel[]))]
    public class RunLogModel
    {

        [DataMember]
        public JobLogModel[] jobLogs { get; set; }
    }

    [DataContract]
    [KnownType(typeof(ScreenShotModel[]))]
    public class JobLogModel
    {

        [DataMember]
        public string job_id { get; set; } //578308ad98e0764c853bd41d4ccacc7826892944"

        [DataMember]
        public string quality { get; set; } //compressed

        [DataMember]
        public int wait_time { get; set; } //5

        [DataMember]
        public string win_res { get; set; } //1280x1024"

        [DataMember]
        public string mac_res { get; set; } //1920x1080"

        [DataMember]
        public string callback_url { get; set; }

        [DataMember]
        public ScreenShotModel[] screenshots { get; set; }
    }

    [DataContract]
    public class ScreenShotModel
    {

        [DataMember]
        public string id { get; set; } //8f4ea390230e7ece787347fa16b0546c6e60615f

        [DataMember]
        public string state { get; set; } //pending

        [DataMember]
        public string url { get; set; } //http://tc-website-ui-html.azurewebsites.net/Pages/Home

        [DataMember]
        public string device { get; set; }

        [DataMember]
        public string os { get; set; } //Windows

        [DataMember]
        public string os_version { get; set; } //8

        [DataMember]
        public string browser { get; set; } //ie

        [DataMember]
        public string browser_version { get; set; } //10.0 Desktop

        [DataMember]
        public string thumb_url { get; set; }

        [DataMember]
        public string image_url { get; set; }

        [DataMember]
        public string created_at { get; set; }
    }

    [DataContract]
    public class MessageModel
    {

        [DataMember]
        public string message { get; set; }
    }
}

