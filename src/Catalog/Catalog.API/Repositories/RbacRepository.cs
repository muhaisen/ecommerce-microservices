using Catalog.API.Data.Interfaces;
using Catalog.API.Entities;
using Catalog.API.Repositories.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Catalog.API.Repositories
{
    public class RbacRepository : IRbacRepository
    {
        private readonly IRbacContext _context;

        public RbacRepository(IRbacContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Principal> GetRole(string Id)
        {
            var principal = await _context
                                .Redis
                                .StringGetAsync(Id);
            if (principal.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Principal>(principal);
        }

        public async Task<Principal> UpdateRole(string Id,List<string> Permissions)
        {
            Principal principal= await GetRole(Id);
            principal.Permissions.AddRange(Permissions);
            var updated = await _context
                              .Redis
                              .StringSetAsync(Id, JsonConvert.SerializeObject(principal));
            if (!updated)
            {
                return null;
            }
            return await GetRole(Id);
        }

        public async Task<bool> DeleteBasket(string Id)
        {
            return await _context
                            .Redis
                            .KeyDeleteAsync(Id);
        }

    }
}
