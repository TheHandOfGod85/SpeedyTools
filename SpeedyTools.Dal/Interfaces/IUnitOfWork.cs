using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        //IAppUserRepository AppUser { get; }
        int Complete();
    }
}
