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

        public async Task<Principal> GetRole(string id)
        {
            var principal = await _context
                                .Redis
                                .StringGetAsync(id);
            if (principal.IsNullOrEmpty)
            {
                return null;
            }
            return JsonConvert.DeserializeObject<Principal>(principal);
        }

        public async Task<Principal> UpdateRole(string id,List<string> permissions)
        {
            System.Diagnostics.Debug.WriteLine(id);
            Principal principal = new() {Id= id, Permissions = permissions };
            var updated = await _context
                              .Redis
                              .StringSetAsync(id, JsonConvert.SerializeObject(principal));
            if (!updated)
            {
                return null;
            }
            return await GetRole(id);
        }

        public async Task<bool> DeleteRole(string id)
        {
            return await _context
                            .Redis
                            .KeyDeleteAsync(id);
        }
    }
}
