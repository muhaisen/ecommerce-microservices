using System.Collections.Generic;

namespace RolesEngine.Entities
{
    public class Principal
    {
        public string Id { get; set; }

        public List<string> Permissions { get; set; }
    }
}
