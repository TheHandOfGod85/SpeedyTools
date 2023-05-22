using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.AppUserS.Responses;
using SpeedyTools.Domain.Models.UserAggregate;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.AppUsers.Queries
{
    public class GetUsersQuery : IRequest<List<AppUserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<AppUserDto>>
    {
        private readonly DataContext _dataContext;
        private readonly UserManager<AppUser> _userManager;
        public GetUsersQueryHandler(DataContext dataContext, UserManager<AppUser> userManager)
        {
            _dataContext = dataContext;
            _userManager = userManager;
        }

        public async Task<List<AppUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            var users = await _dataContext.AppUsers.ToListAsync(); 
            var usersWithRoles = new List<(AppUser User, List<string> Roles)>(); 

            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                usersWithRoles.Add((user, roles.ToList()));
            }

            var result = usersWithRoles.Select(x => new AppUserDto
            {
                Email = x.User.Email,
                LastName = x.User.LastName,
                Name = x.User.Name,
                Shift = x.User.Shift,
                Roles = x.Roles 
            }).ToList();

            return result;
        }
    }
}
