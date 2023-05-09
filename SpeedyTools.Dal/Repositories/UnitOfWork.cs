using SpeedyTools.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.DataAccess.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _dataContext;

        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            AppUser = new AppUserRepository(dataContext);
        }

        public IAppUserRepository AppUser { get; private set; }

        public int Complete()
        {
            return _dataContext.SaveChanges();
        }

        public void Dispose()
        {
            _dataContext.Dispose();
        }
    }
}
