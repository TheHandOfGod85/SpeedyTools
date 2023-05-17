using SpeedyTools.Application.Services.Interfaces;

namespace SpeedyTools.Api.Services.Implementations
{
    public class WebRootPathBuilderService : IWebRootPathBuilder
    {
        private readonly IWebHostEnvironment _webHostEnviroment;

        public WebRootPathBuilderService(IWebHostEnvironment webHostEnviroment)
        {
            _webHostEnviroment = webHostEnviroment;
        }
        public string GetWebRootPath(string folderName, string fileName)
        {
            var pathToFile = _webHostEnviroment.WebRootPath +
                Path.DirectorySeparatorChar.ToString() +
                folderName +
                Path.DirectorySeparatorChar.ToString() +
                fileName;
            return pathToFile;
        }
    }
}
