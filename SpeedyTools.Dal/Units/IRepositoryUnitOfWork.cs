﻿using SpeedyTools.DataAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpeedyTools.DataAccess.Units
{
    public interface IRepositoryUnitOfWork 
    {
        IRepository Repository { get; }
    }
}
