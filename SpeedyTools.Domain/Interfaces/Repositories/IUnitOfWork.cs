using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.Domain.Interfaces.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IAppUserRepository AppUser { get; }
        int Complete();
    }
}
