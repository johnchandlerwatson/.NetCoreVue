using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Vue.Domain
{
    public class Category
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType ItemType { get; set; }
        public List<SubCategory> Subcategories { get; set; } = new List<SubCategory>();
    }

    public class SubCategory
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemType ItemType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemSubType ItemSubType { get; set; }
        public List<ItemOrder> Items { get; set; }
    }
}