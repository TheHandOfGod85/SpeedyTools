using MediatR;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class CreateRoleCommand : IRequest<string>
    {
        public CreateRoleCommand(string roleName)
        {
            RoleName = roleName;
        }
        public string RoleName { get; set; }
    }


    public class CreateRoleCommandHandler : IRequestHandler<CreateRoleCommand, string>
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public CreateRoleCommandHandler(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }
        public async Task<string> Handle(CreateRoleCommand request, CancellationToken cancellationToken)
        {
            if (!_roleManager.RoleExistsAsync(request.RoleName).GetAwaiter().GetResult())
            {
                await _roleManager.CreateAsync(new IdentityRole(request.RoleName));
                return $"Role {request.RoleName} was created successfully";
            }
            return $"Role {request.RoleName} already exist";
        }
    }
}
