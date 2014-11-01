using System.IO;

namespace TC.BrowserStack.Screenshots
{
    public class JsonFile
    {
        public static T ReadObject<T>(string path)
        {
            string fullPath = Path.GetFullPath(path);

            string json = File.ReadAllText(fullPath);

            T value = Json.Deserialize<T>(json);

            return value;
        }

        public static T ReadObject<T>(Stream stream)
        {
            StreamReader reader = new StreamReader(stream, true);

            string json = reader.ReadToEnd();

            T value = Json.Deserialize<T>(json);

            return value;
        }

        public static void WriteObject(object value, string path)
        {
            string json = Json.Serialize(value);

            json = formatJson(json);

            string fullPath = Path.GetFullPath(path);

            File.WriteAllText(fullPath, json);
        }

        private static string formatJson(string json)
        {
            json = json.Replace("[{", "[\r\n\t{");
            json = json.Replace("},{", "},\r\n\t{");
            json = json.Replace("}]", "}\r\n]");

            return json;
        }
    }
}
