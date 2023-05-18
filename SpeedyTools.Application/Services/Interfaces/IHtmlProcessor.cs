using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IHtmlProcessor
    {
        string ProcessHtml(string html, List<string> replacements);
    }
}
