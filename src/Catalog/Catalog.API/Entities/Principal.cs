using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace Catalog.API.Entities
{
    public class Principal
    {
        public string Id { get; set; }

        public List<string> Permissions { get; set; }
    }
}
