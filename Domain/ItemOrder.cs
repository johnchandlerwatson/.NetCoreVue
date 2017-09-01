using System;

namespace Vue.Domain
{
    public class ItemOrder
    {
        public Guid Id { get; set; }
        public DateTime TimeRequested { get; set; }
        public DateTime? TimeReceived { get; set; }
        public Item Item { get; set; }
    }
}