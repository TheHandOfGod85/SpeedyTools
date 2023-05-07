using SpeedyTools.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.DataAccess.Units.Implementations
{
    public class RepositoryUnitOfWork : IRepositoryUnitOfWork
    {
        public IRepository Repository { get; }

        public RepositoryUnitOfWork(IRepository repository)
        {
            Repository = repository;
        }
    }
}
