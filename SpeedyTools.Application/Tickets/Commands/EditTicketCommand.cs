using MediatR;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.Tickets.Commands
{
    public class EditTicketCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Guid AppUserId { get; set; }
    }

    public class EditTicketCommandHandler : IRequestHandler<EditTicketCommand, bool>
    {
        private readonly DataContext _dataContext;
        public EditTicketCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Handle(EditTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _dataContext.Tickets
                .Where(x => x.AppUserId == request.AppUserId)
                .FirstOrDefault(x => x.Id == request.Id);
            if (ticket == null) { return false; }
            ticket.Title = request.Title;
            ticket.Description = request.Description;
            ticket.LastModified = DateTime.UtcNow;
            _dataContext.Tickets.Update(ticket);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
