using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.Tickets.Responses;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Domain.Models.UserAggregate;
using SpeedyTools.Infrastructure;


namespace SpeedyTools.Application.Tickets.Queries
{
    public class GetTicketsByAdminQuery : IRequest<List<TicketDto>>
    {
    }

    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsByAdminQuery, List<TicketDto>>
    {
        private readonly DataContext _dataContext;
        public GetTicketsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsByAdminQuery request, CancellationToken cancellationToken)
        {
            var tickets = await (from ticket in _dataContext.Tickets
                join appUser in _dataContext.AppUsers on ticket.AppUserId.ToString() equals appUser.Id
                select new TicketDto
                {
                    Title = ticket.Title,
                    Id = ticket.Id,
                    Description = ticket.Description,
                    Closed = ticket.Closed,
                    Created = ticket.Created,
                    LastModified = ticket.LastModified,
                    AppUserId = ticket.AppUserId,
                    AppUserName = appUser.Name
                }).ToListAsync();

            return tickets;
        }
    }
}
