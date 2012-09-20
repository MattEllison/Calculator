using System.Collections.Generic;
using System.IO;

namespace Services
{
    public class FileService
    {
        public IEnumerable<string> GetLinesFromFile(string filePath)
        {
            string line;
            using (var reader = File.OpenText(filePath))
            {
                while ((line = reader.ReadLine()) != null)
                {
                    yield return line;
                }
            }
        }
    }
}
