using System;

namespace Vue.Domain
{
    public class ItemOrder
    {
        public Guid Id { get; set; }
        public DateTime TimeRequested { get; set; }
        public DateTime? TimeReceived { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public int MinutesWaiting => DateTime.Now.Subtract(TimeRequested).Minutes;
        public decimal WarningLevel => GetWarningLevel(MinutesWaiting);
        private decimal GetWarningLevel(int minutes)
        {
            return minutes > 15 ? 3 
                 : minutes > 10 ? 2 
                 : minutes >  5 ? 1 
                 : 0;
        }
    }
}