using StackExchange.Redis;

namespace RolesEngine.Data.Interfaces
{
    public interface IRolesEngineContext
    {
        IDatabase Redis { get; }
    }
}
