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
        public List<decimal> AllWarnings => Orders.SelectMany(x => x.Items.Select(y => y.WarningLevel)).ToList();
        public int AvgWarningLevel => AllWarnings == null || !AllWarnings.Any() 
            ? 0 : (int) AllWarnings.Average(x => x);
        public int OrderCount => Orders?.Count() ?? 0;
        public int MaxMinutesWaiting => Orders.Any() ? Orders?.SelectMany(x => x.Items.Select(y => y.MinutesWaiting))?.Max() ?? 0 : 0;
    }
}