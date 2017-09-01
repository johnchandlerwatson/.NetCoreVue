using System;

namespace Vue.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        public ItemType ItemType { get; set; }
    }

    public enum ItemType
    {
        Food, 
        Drink
    }
}