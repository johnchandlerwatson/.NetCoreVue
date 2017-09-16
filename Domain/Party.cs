using System;
using System.Collections.Generic;
using System.Linq;

namespace Vue.Domain
{
    public class Party
    {
        public Guid Id { get; set; }
        public Table Table { get; set; }
        public Waiter Waiter { get; set; }
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<Order> OutStandingOrders => Orders.Where(x => x.OutstandingItems.Any()).ToList();
        public DateTime? CheckoutTime { get; set; }   
        public List<decimal> AllWarnings => Orders.SelectMany(x => x.Items.Select(y => y.WarningLevel)).ToList();
        public int AvgWarningLevel => AllWarnings == null || !AllWarnings.Any() 
            ? 0 : (int) AllWarnings.Average(x => x);
        public int OutstandingOrderCount => OutStandingOrders?.Count() ?? 0;
        public int MaxMinutesWaiting => Orders.Any() ? Orders?.SelectMany(x => x.Items.Select(y => y.MinutesWaiting))?.Max() ?? 0 : 0;
        public List<Tax> Taxes { get; set; } = new List<Tax>();
        public Discount Discount { get; set; }

        public double Subtotal => Orders.Sum(x => x.Items.Sum(y => y.Item.Price * y.Quantity));
        public string SubtotalDisplay => Subtotal.ToString("C2");
        public double TotalAfterDiscount => Subtotal - DiscountAmount;
        public double DiscountAmount => Discount == null ? 0 : Subtotal * Discount.Percent;
        public string DiscountAmountDisplay => DiscountAmount.ToString("C2");
        public double TaxAmount => CalculateTaxes();
        public string TaxAmountDisplay => TaxAmount.ToString("C2");
        public double TotalAfterTaxes => TotalAfterDiscount + TaxAmount;
        public string TotalAfterTaxesDisplay => TotalAfterTaxes.ToString("C2");

        private double CalculateTaxes()
        {
            var taxAmount = 0.0;
            foreach (var tax in Taxes)
            {
                taxAmount += (TotalAfterDiscount * tax.Percent);
            }
            return taxAmount;
        }
    }
}