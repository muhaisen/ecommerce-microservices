using StackExchange.Redis;

namespace Catalog.API.Data.Interfaces
{
    public interface IRbacContext
    {
        IDatabase Redis { get; }
    }
}
