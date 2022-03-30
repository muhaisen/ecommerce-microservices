using RolesEngine.Data.Interfaces;
using StackExchange.Redis;

namespace RolesEngine.Data
{
    public class RolesEngineContext : IRolesEngineContext
    {
        public RolesEngineContext(ConnectionMultiplexer redisConnection)
        {
            Redis = redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
