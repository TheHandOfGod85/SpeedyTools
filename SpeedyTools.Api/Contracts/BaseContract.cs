namespace SpeedyTools.Api.Contracts
{
    public abstract class BaseContract<T> where T : SpeedyTools.Application.Contracts.BaseContract
    {
        public abstract T Map();
        public virtual void Throw()
        {
            Console.WriteLine("Ciao");
        }
    }
}
