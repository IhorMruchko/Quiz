using Newtonsoft.Json;
using System;

namespace Quiz.Standart.Services
{
    public static class JsonSerializer
    {
        public static JsonSerializerSettings Settings { get; set; } = new JsonSerializerSettings()
        {
            Formatting = Formatting.Indented,
            TypeNameHandling = TypeNameHandling.All,
        };

        public static TDeserialize Deserialize<TDeserialize>(string textData)
        {
            try
            {
                return JsonConvert.DeserializeObject<TDeserialize>(textData, Settings);
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static string Serialize<TDeserialize>(TDeserialize serializedObject)
        {
            try
            {
                return JsonConvert.SerializeObject(serializedObject, Settings);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }
    }
}