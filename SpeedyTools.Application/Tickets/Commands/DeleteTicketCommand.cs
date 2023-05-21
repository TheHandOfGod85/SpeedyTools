using MediatR;
using SpeedyTools.Infrastructure;

namespace SpeedyTools.Application.Tickets.Commands
{
    public class DeleteTicketCommand : IRequest<bool>
    {
        public required Guid Id { get; set; }
    }

    public class DeleteTicketCommandHandler : IRequestHandler<DeleteTicketCommand, bool>
    {
        private readonly DataContext _dataContext;

        public DeleteTicketCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<bool> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = _dataContext.Tickets.FirstOrDefault(x => x.Id == request.Id);
            if (ticket == null) { return false; }
            _dataContext.Tickets.Remove(ticket);
            return await _dataContext.SaveChangesAsync() > 0;
        }
    }
}
