using MediatR;
using Microsoft.EntityFrameworkCore;
using SpeedyTools.Application.Contracts.Tickets.Responses;
using SpeedyTools.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Tickets.Queries
{
    public class GetTicketsQuery : IRequest<List<TicketDto>>
    {
    }

    public class GetTicketsQueryHandler : IRequestHandler<GetTicketsQuery, List<TicketDto>>
    {
        private readonly DataContext _dataContext;
        public GetTicketsQueryHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<TicketDto>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            return await _dataContext.Tickets
                .AsNoTracking()
                .Select(x => new TicketDto
                {
                    Title = x.Title,
                    Id = x.Id,
                    Description = x.Description,
                    Closed = x.Closed,
                    Created = x.Created,
                    LastModified = x.LastModified,
                    AppUserId = x.AppUserId
                })
                .ToListAsync();
        }
    }
}
