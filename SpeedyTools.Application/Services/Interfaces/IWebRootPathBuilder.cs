using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IWebRootPathBuilder
    {
        string GetWebRootPath(string folderName, string fileName);
    }
}
