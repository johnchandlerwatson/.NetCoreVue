using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vue.Domain
{
    public class Item
    {
        public Guid Id { get; set; }
        public double Price { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType ItemType => Dictionary[ItemSubType];
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemSubType ItemSubType { get; set; }

        private Dictionary<ItemSubType, ItemType> Dictionary => new Dictionary<ItemSubType, ItemType>
        {
            { ItemSubType.Entree, ItemType.Food },
            { ItemSubType.Salad, ItemType.Food },
            { ItemSubType.Sandwich, ItemType.Food },       
            { ItemSubType.App, ItemType.Food },
            { ItemSubType.Soda, ItemType.Drink }
        };
    }

    public enum ItemType
    {
        Food, 
        Drink
    }

    public enum ItemSubType
    {
        Soda, 
        Salad, 
        Sandwich,
        Entree,
        App
    }
}