using QuestionVisualisation.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public class IOManagerTxt : IOManager
    {
        public string FileFormat => ".txt";

        public IEnumerable<TReadObject>? ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new()
        {
            var lines = File.ReadAllLines(filePath);
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
            return result;
        }

        public void WriteToFile<TWriteObject>(string filePath, IEnumerable<TWriteObject> values)
            where TWriteObject: class, new()
        {
            File.WriteAllText(
                filePath,
                string.Join("\n", values.Select(v => string.Join("*", v.GetType().GetProperties().Select(p => p.GetValue(v))))));
        }
    }
}
