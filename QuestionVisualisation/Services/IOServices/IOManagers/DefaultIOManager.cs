using System.Collections.Generic;
using System.Linq;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public class DefaultIOManager : IOManager
    {
        public string FileFormat => string.Empty;

        public IEnumerable<TReadObject>? ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new()
        {
            return Enumerable.Empty<TReadObject>();
        }

        public void WriteToFile<TWriteObject>(string filePath, IEnumerable<TWriteObject> values)
            where TWriteObject : class, new()
        {
            
        }
    }
}
