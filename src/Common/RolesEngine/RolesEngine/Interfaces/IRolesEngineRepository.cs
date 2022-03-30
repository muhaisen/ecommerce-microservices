using RolesEngine.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RolesEngine.Repositories.Interfaces
{
    public interface IRolesEngineRepository
    {
        Task<Principal> GetRole(string id);
        Task<Principal> UpdateRole(string id, List<string> permissions);
        Task<bool> DeleteRole(string id);

    }
}
