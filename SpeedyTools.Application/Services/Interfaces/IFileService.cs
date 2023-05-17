using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IFileService
    {
        string ReadFile(string filePath, string file);
    }
}
