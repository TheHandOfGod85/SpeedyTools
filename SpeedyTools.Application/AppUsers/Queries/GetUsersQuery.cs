using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.AppUserS.Responses;
using SpeedyTools.Application.Contracts.Tickets.Responses;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Queries
{
    public class GetUsersQuery :IRequest<List<AppUserDto>>
    {
    }

    public class GetUsersQueryHandler : IRequestHandler<GetUsersQuery, List<AppUserDto>>
    {
        private readonly UserManager<AppUser> _userManager;
        public GetUsersQueryHandler(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<AppUserDto>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await _userManager.Users
                .Include(u => u.Tickets)
                .AsNoTracking()
                .Select(x => new AppUserDto
                { 
                    Email = x.Email,
                    LastName = x.LastName,
                    Name = x.Name,
                    Shift = x.Shift,
                    Tickets = x.Tickets.Select(t => new TicketDto // Map tickets to TicketDto
                    {
                        Id = t.Id,
                        Title = t.Title,
                        Created = t.Created,
                        Closed = t.Closed,
                        Description = t.Description,
                        LastModified = t.LastModified
                    }).ToList()
                })
                .ToListAsync();
        }
    }
}
