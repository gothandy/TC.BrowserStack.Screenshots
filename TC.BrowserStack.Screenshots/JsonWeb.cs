using System;
using System.Net;
using System.Text;

namespace TC.BrowserStack.Screenshots
{
    public class JsonWeb
    {
        public static T DownloadObject<T>(string url)
        {
            T download;

            using (var web = new WebClient())
            {
                string json = web.DownloadString(url);

                download = Json.Deserialize<T>(json);
            }

            return download;
        }

        public static responseT UploadObject<responseT, postT>(postT post, string url, string username, string password)
        {
            responseT value;

            string json = Json.Serialize<postT>(post);
            string response;

            using (var web = new WebClient())
            {
                web.Headers[HttpRequestHeader.Authorization] = "Basic " + Convert.ToBase64String(Encoding.ASCII.GetBytes(username + ":" + password));
                web.Headers[HttpRequestHeader.ContentType] = "application/json";
                web.Headers[HttpRequestHeader.Accept] = "application/json";

                response = web.UploadString(url, "POST", json);
            }

            value = Json.Deserialize<responseT>(response);

            return value;
        }
    }
}
