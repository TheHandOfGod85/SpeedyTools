using SpeedyTools.Application.Services.Interfaces;

namespace SpeedyTools.Application.Services.Implementations
{
    public class HtmlProcessor : IHtmlProcessor
    {
        private readonly IFileService _fileService;

        public HtmlProcessor(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string ProcessHtml(string pathToFile, List<string> replacements)
        {
            var htmlBody = "";
            var htmlBodyRead = _fileService.ReadFile(pathToFile, htmlBody);
            int count = 0;
            foreach (var newString in replacements)
            {
                string placeholder = $"{{{count}}}";
                htmlBodyRead = htmlBodyRead.Replace(placeholder, newString);
                count++;
            }
            return htmlBodyRead;
        }
    }
}
