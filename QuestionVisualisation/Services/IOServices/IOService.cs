using QuestionVisualisation.Extensions;
using QuestionVisualisation.Services.IOServices.IOManagers;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuestionVisualisation.Services.IOServices
{
    public static class IOService
    {
        public static IEnumerable<TReadObject> ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new()
        {
            /*var lines = File.ReadAllLines(filePath);
            var properties = new TReadObject().GetType().GetProperties();
            var result = new List<TReadObject>();

            foreach (var line in lines)
            {
                if (line.Length == 0)
                {
                    continue;
                }

                var newObject = new TReadObject();
                foreach (var (property, value) in properties.Zip(line.Split('*')))
                {
                    property.TrySetValue(newObject, value);
                }

                result.Add(newObject);
            }
            return result;*/
            return new IOManagerJson().ReadFromFile<TReadObject>(filePath);
        }

        public static void WriteToFile<T>(string filePath, IEnumerable<T> values)
        {
            new IOManagerJson().WriteToFile(filePath, values);
        }
    }
}