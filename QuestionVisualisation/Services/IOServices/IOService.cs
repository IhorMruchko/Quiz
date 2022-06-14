using System;
using System.Collections.Generic;
using System.Linq;
using QuestionVisualisation.Services.IOServices.IOManagers;

namespace QuestionVisualisation.Services.IOServices
{
    public static class IOService
    {
        private static readonly List<IOManager> _managers;

        static IOService()
        {
            _managers = new List<IOManager>()
            {
                new IOManagerJson(),
                new IOManagerTxt()
            };
        }

        private static IOManager GetManager(string filePath) 
            => _managers.FirstOrDefault(m => filePath.EndsWith(m.FileFormat)) ?? new DefaultIOManager();
        
        public static IEnumerable<TReadObject> ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new()
        {
            return GetManager(filePath).ReadFromFile<TReadObject>(filePath) ?? Enumerable.Empty<TReadObject>();
        }

        public static void WriteToFile<TWriteObject>(string filePath, IEnumerable<TWriteObject> values)
            where TWriteObject : class, new()

        {
            GetManager(filePath).WriteToFile(filePath, values);
        }
    }
}