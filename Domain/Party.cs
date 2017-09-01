using System;
using System.Collections.Generic;
using System.Linq;

namespace Vue.Domain
{
    public class Party
    {
        public Guid Id { get; set; }
        public Table Table { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public DateTime? CheckoutTime { get; set; }
        public double Total => Orders.Sum(x => x.Items.Sum(y => y.Item.Price));
    }
}