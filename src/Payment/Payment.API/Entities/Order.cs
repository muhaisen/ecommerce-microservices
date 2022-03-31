using Catalog.API.Entities;
using System;

namespace Payment.API.Entities
{
    public class Order
    {
        public string Id { get; set; }

        public int Quantity { get; set; }

        public bool IsPayed { get; set; }

        public Product Product { get; set; }

        public DateTime Date { get; set; }

        public decimal Price { get; set; }
    }
}
