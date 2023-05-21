using MediatR;
using SpeedyTools.Domain.Models.TicketAggregate;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.Tickets.Commands
{
    public class CreateTicketCommand : IRequest<string>
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public Guid AppUserId { get; set; }

        internal Ticket CreateTicket()
        {
            return new Ticket
            {
                Id = Guid.NewGuid(),
                Title = Title,
                Created = DateTime.Now,
                Description = Description,
                AppUserId = AppUserId
            };
        }
    }

    public class CreateTicketCommandHandler : IRequestHandler<CreateTicketCommand, string>
    {
        private readonly DataContext _dataContext;
        public CreateTicketCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<string> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = request.CreateTicket();
            _dataContext.Tickets.Add(ticket);
            await _dataContext.SaveChangesAsync();
            return ticket.Id.ToString();
        }
    }
}
