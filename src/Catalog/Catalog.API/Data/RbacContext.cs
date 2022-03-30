using Catalog.API.Data.Interfaces;
using StackExchange.Redis;

namespace Catalog.API.Data
{
    public class RbacContext : IRbacContext
    {
        public RbacContext(ConnectionMultiplexer redisConnection)
        {
            Redis = redisConnection.GetDatabase();
        }

        public IDatabase Redis { get; }
    }
}
