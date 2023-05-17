using SpeedyTools.Application.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Implementations
{
    public class FileService : IFileService
    {
        public string ReadFile(string filePath, string file)
        {
            using (StreamReader streamReader = System.IO.File.OpenText(filePath))
            {
                file = streamReader.ReadToEnd();
            }
            return file;
        }
    }
}
