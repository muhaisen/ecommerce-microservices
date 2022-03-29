using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IRbacRepository
    {
        Task<Principal> GetRole(string Id);
        Task<Principal> UpdateRole(string Id, List<string> Permissions);
    }
}
