

using FluentValidation;
using SpeedyTools.Domain.Models.UserAggregate;

namespace SpeedyTools.Api.Contracts
{
    public class CreateUserDto : BaseContract<AppUser>
    {
        public Guid AppUserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Shift { get; set; }
        public Roles Role { get; set; } 

        public override AppUser Map()
        {
            return new AppUser
            {
                AppUserId = Guid.NewGuid(),
                Name = Name,
                LastName = LastName,
                Shift = Shift,
                Role = (Domain.Models.UserAggregate.Roles)Role,
            };
        }
    }

    public enum Roles
    {
        MasterUser,
        Engineer,
        SimpleUser
    }

    public class CreateUserValidator : AbstractValidator<CreateUserDto>
    {
        public CreateUserValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name is required");
            RuleFor(x => x.Shift).NotEmpty().WithMessage("Shift is required");
        }
    }
}
