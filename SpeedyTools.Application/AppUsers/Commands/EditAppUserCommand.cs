using MediatR;
using Microsoft.EntityFrameworkCore;
using SendGrid.Helpers.Errors.Model;
using SpeedyTools.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class EditAppUserCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    } 
   

    public class EditedAppUserCommandHandler : IRequestHandler<EditAppUserCommand>
    {
        private readonly DataContext _dataContext;

        public EditedAppUserCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task Handle(EditAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = await _dataContext.AppUsers.FirstOrDefaultAsync(x => x.Id == request.Id);

            if (appUser == null) { throw new NotFoundException("User not found"); }

            appUser.Name = request.Name;
            appUser.LastName = request.LastName;
            appUser.Shift = request.Shift;

            _dataContext.AppUsers.Update(appUser);
            await _dataContext.SaveChangesAsync();
        }
    }
}
