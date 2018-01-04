using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Models
{
    public class Order
    {
        public Guid Id { get; set; }

        public int Quantity { get; set; }

        public Item Item { get; set; }
    }
}
