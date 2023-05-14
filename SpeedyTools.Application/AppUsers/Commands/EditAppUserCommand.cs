using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using SpeedyTools.DataAccess;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class EditAppUserCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }


    public class EditedAppUserCommandHandler : IRequestHandler<EditAppUserCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;

        public EditedAppUserCommandHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<bool> Handle(EditAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.Id.ToString());
            if (appUser == null) { throw new Exception("User not found"); }
            appUser.Name = request.Name ?? appUser.Name;
            appUser.LastName = request.LastName ?? appUser.LastName;
            appUser.Shift = request.Shift ?? appUser.Shift;

           var result = await _userManager.UpdateAsync(appUser);
            if (result.Succeeded) { return true; }
            throw new Exception("User was not updated");
        }
    }
}
