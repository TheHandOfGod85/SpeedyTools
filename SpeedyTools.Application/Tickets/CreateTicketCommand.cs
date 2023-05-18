using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.Tickets
{
    public class CreateTicketCommand : IRequest<Guid>
    {
        public Guid TicketId { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public string Description { get; set; }
        public Guid AppUserId { get; set; }
    }
}
