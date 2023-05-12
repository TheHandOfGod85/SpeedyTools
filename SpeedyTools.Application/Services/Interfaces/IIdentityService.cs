using SpeedyTools.Application.Contracts.Requests;
using SpeedyTools.Application.Contracts.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Services.Interfaces
{
    public interface IIdentityService
    {
        public Task<ServiceResult<string>> RegisterUser(RegisterUserDto register);
    }
}
