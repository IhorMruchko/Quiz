using System.Collections.Generic;
using System.Linq;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public class DefaultIOManager : IOManager
    {
        public string FileFormat => string.Empty;

        public IEnumerable<T>? ReadFromFile<T>(string filePath)
        {
            return Enumerable.Empty<T>();
        }

        public void WriteToFile<T>(string filePath, IEnumerable<T> values)
        {
            
        }
    }
}
