using Microsoft.AspNetCore.WebUtilities;
using SpeedyTools.Application.Services.Interfaces;
using System.Text;

namespace SpeedyTools.Api.Services.Implementations
{
    public class WebEncoderService : IEncoderService
    {
        public void Encode(string input)
        {
            WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(input));
        }
    }
}
