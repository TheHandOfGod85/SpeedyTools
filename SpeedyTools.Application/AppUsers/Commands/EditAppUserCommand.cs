using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Domain.Models.UserAggregate;


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
            if (appUser == null) { return false; }
            appUser.Name = request.Name;
            appUser.LastName = request.LastName ;
            appUser.Shift = request.Shift;

            var result = await _userManager.UpdateAsync(appUser);
            return result.Succeeded;
        }
    }
}
