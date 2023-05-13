using MediatR;
using SpeedyTools.DataAccess;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Application.AppUsers.Commands
{
    public class CreateAppUserCommand : IRequest<Guid>
    {

        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
    }


    public class CreateAppUserCommandHandler : IRequestHandler<CreateAppUserCommand, Guid>
    {
        private readonly DataContext _dataContext;
        public CreateAppUserCommandHandler(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<Guid> Handle(CreateAppUserCommand request, CancellationToken cancellationToken)
        {
            var appUser = new AppUser
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                LastName = request.LastName,
                Shift = request.Shift,
            };
            var result = _dataContext.AppUsers.Add(appUser);
            await _dataContext.SaveChangesAsync();
            if (result is null) { throw new Exception("User was not created"); }
            return appUser.Id;
        }
    }
}
