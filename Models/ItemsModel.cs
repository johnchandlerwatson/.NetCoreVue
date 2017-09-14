using System.Collections.Generic;
using Vue.Domain;

namespace Vue.Models
{
    public class OrderModel 
    {
        public List<Category> Categories { get; set; } = new List<Category>();
        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }
    }
}