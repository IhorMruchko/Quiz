using QuestionVisualisation.Services.IOServices.IOManagers;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace QuestionVisualisation.Services.IOServices
{
    public static class IOService
    {
        private static List<IOManager> _managers = new()
        {
            new IOManagerJson(),
        };

        private static IOManager GetManager(string filePath) 
            => _managers.FirstOrDefault(m => filePath.EndsWith(m.FileFormat)) ?? new DefaultIOManager();
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
            return GetManager(filePath).ReadFromFile<TReadObject>(filePath) ?? Enumerable.Empty<TReadObject>();
        }

        public static void WriteToFile<T>(string filePath, IEnumerable<T> values)
        {
            GetManager(filePath).WriteToFile(filePath, values);
        }
    }
}