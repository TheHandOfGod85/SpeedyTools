using System;

namespace SpeedyTools.Application.Contracts
{
    public abstract class BaseContract<T> where T : class
    {
        public abstract T Map();

    }
}
