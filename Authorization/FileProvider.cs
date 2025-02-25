using System.IO;
using System.Text.Json;

namespace Authorization
{
    public static class FileProvider
    {
        public static void Save(object data, string fileName)
        {
            string serializeData = JsonSerializer.Serialize(data);

            if (File.Exists(fileName))
            {
                File.WriteAllText(fileName, serializeData);
            }
            else
            {
                File.Create(fileName).Close();
                File.WriteAllText(fileName, serializeData);
            }
        }

        public static T Load<T>(string fileName)
        {
            if (!File.Exists(fileName))
            {
                return default;
            }
            var jsonString = File.ReadAllText(fileName);
            if (string.IsNullOrEmpty(jsonString))
            {
                return default;
            }
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
