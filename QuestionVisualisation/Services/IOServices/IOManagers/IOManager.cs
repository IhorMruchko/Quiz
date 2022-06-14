using System.Collections.Generic;

namespace QuestionVisualisation.Services.IOServices.IOManagers
{
    public interface IOManager
    {
        string FileFormat { get; }

        IEnumerable<TReadObject>? ReadFromFile<TReadObject>(string filePath)
            where TReadObject : class, new();

        void WriteToFile<TWriteObject>(string filePath, IEnumerable<TWriteObject> values)
            where TWriteObject : class, new();
    }
}
