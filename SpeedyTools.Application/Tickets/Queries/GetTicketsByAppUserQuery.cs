using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.Tickets.Responses;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.Tickets.Queries
{
    public class GetTicketsByAppUserQuery : IRequest<List<TicketDto>>
    {
        public required Guid Id { get; set; }
    }

    public class GetAppUserTicketsQueryHandler : IRequestHandler<GetTicketsByAppUserQuery, List<TicketDto>>
    {
        protected readonly DataContext _dataContext;

        public GetAppUserTicketsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsByAppUserQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Tickets
                .Where(x => x.AppUserId == request.Id)
                .Select(t => new TicketDto
                {
                    Title = t.Title,
                    Id = t.Id,
                    Description = t.Description,
                    Closed = t.Closed,
                    Created = t.Created,
                    LastModified = t.LastModified,
                    AppUserId = t.AppUserId,
                })
                .ToListAsync();
        }
    }
}
