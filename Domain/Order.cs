using System;
using System.Collections.Generic;
using System.Linq;

namespace Vue.Domain
{
    public class Order 
    {
        public Guid Id { get; set; }
        public List<ItemOrder> Items { get; set; } = new List<ItemOrder>();
        public double Total => Items.Sum(x => x.Item.Price);
    }
}