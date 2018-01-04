using System;

namespace Basket.Models
{
    public class Item
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public decimal Price { get; set; }
    }
}
