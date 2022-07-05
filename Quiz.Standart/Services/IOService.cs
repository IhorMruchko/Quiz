using System;
using System.IO;

namespace Quiz.Standart.Services
{
    public static class IoService
    {
        public static TReadObject Read<TReadObject>(string filePath)
        {
            try
            {
                return JsonSerializer.Deserialize<TReadObject>(File.ReadAllText(filePath));
            }
            catch (Exception)
            {
                return default;
            }
        }

        public static void Write<TWrittenObject>(string filePath, TWrittenObject value)
        {
            File.WriteAllText(filePath, JsonSerializer.Serialize(value));
        }
    }
}