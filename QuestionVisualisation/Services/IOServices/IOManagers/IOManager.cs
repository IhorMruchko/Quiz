using System.Collections.Generic;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public interface IOManager
    {
        string FileFormat { get; }

        IEnumerable<T>? ReadFromFile<T>(string filePath);

        void WriteToFile<T>(string filePath, IEnumerable<T> values);
    }
}
