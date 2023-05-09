using System;

namespace SpeedyTools.Api.Contracts
{
    public abstract class BaseContract<T> where T : class 
    {
        public abstract T Map();
        
    }
}
