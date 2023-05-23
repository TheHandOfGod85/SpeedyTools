using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.Tickets.Responses;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.Tickets.Queries
{
    public class GetTicketByAppUserQuery : IRequest<TicketDto?>
    {
        public required Guid Id { get; set; }
        public required Guid AppUserId { get; set; }
    }

    public class GetTicketQueryHandler : IRequestHandler<GetTicketByAppUserQuery, TicketDto?>
    {
        private readonly DataContext _dataContext;
        public GetTicketQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<TicketDto?> Handle(GetTicketByAppUserQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Tickets
                   .Where(x => x.AppUserId == request.AppUserId)
                   .Select(x => new TicketDto
                   {
                       Title = x.Title,
                       Id = x.Id,
                       Description = x.Description,
                       Closed = x.Closed,
                       Created = x.Created,
                       LastModified = x.LastModified,
                       AppUserId = x.AppUserId,
                   })
                   .FirstOrDefaultAsync(x => x.Id == request.Id);
        }
    }
}
