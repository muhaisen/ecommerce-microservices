using Catalog.API.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories.Interfaces
{
    public interface IRbacRepository
    {
        Task<Principal> GetRole(string id);
        Task<Principal> UpdateRole(string id, List<string> permissions);
        Task<bool> DeleteRole(string id);

    }
}
