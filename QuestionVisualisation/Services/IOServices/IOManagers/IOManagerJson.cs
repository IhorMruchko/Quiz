using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public class IOManagerJson : IOManager
    {
        public string FileFormat => ".json";

        public IEnumerable<TReadObject>? ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new()
        {
            var allText = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<IEnumerable<TReadObject>>(allText);
        }

        public void WriteToFile<TWriteObject>(string filePath, IEnumerable<TWriteObject> values)
            where TWriteObject: class, new()
        {
           var result = JsonSerializer.Serialize(values);
           File.WriteAllText(filePath, result);
        }
    }
}
