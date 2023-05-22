using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Domain.Models.UserAggregate;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class EditAppUserCommand : IRequest<bool>
    {
        public Guid AppUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }


    public class EditedAppUserCommandHandler : IRequestHandler<EditAppUserCommand, bool>
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly DataContext _dataContext;

        public EditedAppUserCommandHandler(UserManager<AppUser> userManager, DataContext dataContext)
        {
            _userManager = userManager;
            _dataContext = dataContext;
        }
        public async Task<bool> Handle(EditAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _userManager.Users.FirstOrDefaultAsync(x => x.Id == request.AppUserId.ToString());
            if (appUser == null) { return false; }
            appUser.Name = request.Name;
            appUser.LastName = request.LastName ;
            appUser.Shift = request.Shift;

            _dataContext.Update(appUser);
            var result = await _dataContext.SaveChangesAsync() > 0;
            return result;
        }
    }
}
