using SpeedyTools.Domain.Interfaces.Repositories;
using SpeedyTools.Domain.Models.UserAggregate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.DataAccess.Repositories
{
    public class AppUserRepository : Repository<AppUser>, IAppUserRepository
    {
        public AppUserRepository(DataContext context) : base(context)
        {
        }
    }
}
