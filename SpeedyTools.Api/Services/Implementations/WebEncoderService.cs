using Microsoft.AspNetCore.WebUtilities;
using SpeedyTools.Application.Services.Interfaces;
using System.Text;

namespace SpeedyTools.Api.Services.Implementations
{
    public class WebEncoderService : IEncoderService
    {
        public string Decode(string input)
        {
           var decodedTokenBytes =  WebEncoders.Base64UrlDecode(input);
           var decodedToken = Encoding.UTF8.GetString(decodedTokenBytes);
            return decodedToken;
        }

        public string Encode(string input)
        {
           var encoded = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(input));
            return encoded;
        }
    }
}
