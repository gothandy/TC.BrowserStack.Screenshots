using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace TC.BrowserStack.Screenshots
{
    //http://www.codeproject.com/Articles/272335/JSON-Serialization-and-Deserialization-in-ASP-NET
    public class Json
    {
        public static string Serialize(object value)
        {
            throw (new NotImplementedException());
        }

        public static string Serialize<T>(T value)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));

            MemoryStream ms = new MemoryStream();

            ser.WriteObject(ms, value);
            string jsonString = Encoding.UTF8.GetString(ms.ToArray());
            ms.Close();
            return jsonString;
        }

        public static T Deserialize<T>(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(T));
            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            T obj = (T)ser.ReadObject(ms);
            return obj;
        }
    }
}
