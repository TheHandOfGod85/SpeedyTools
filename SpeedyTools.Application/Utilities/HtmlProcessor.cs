using SpeedyTools.Application.Services.Interfaces;

namespace SpeedyTools.Application.Utilities
{
    public  class HtmlProcessor : IHtmlProcessor
    {
        private readonly IFileService _fileService;

        public HtmlProcessor(IFileService fileService)
        {
            _fileService = fileService;
        }

        public string ProcessHtml(string pathToFile)
        {
            var htmlBody = "";
            var htmlBodyRead = _fileService.ReadFile(pathToFile, htmlBody);
            return htmlBodyRead;
        }
    }
}
