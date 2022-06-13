using System.Collections.Generic;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public interface IOManager
    {
        IEnumerable<T> ReadFromFile<T>(string filePath);

        void WriteToFile<T>(string filePath, IEnumerable<T> values);
    }
}
