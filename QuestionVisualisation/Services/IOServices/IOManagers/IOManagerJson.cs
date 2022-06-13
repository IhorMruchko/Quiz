using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public class IOManagerJson : IOManager
    {
        public IEnumerable<T> ReadFromFile<T>(string filePath)
        {
            var allText = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IEnumerable<T>>(allText);
        }

        public void WriteToFile<T>(string filePath, IEnumerable<T> values)
        {
           var result = JsonSerializer.Serialize(values);
           File.WriteAllText(filePath, result);
        }
    }
}
