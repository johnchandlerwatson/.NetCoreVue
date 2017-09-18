using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Vue.Domain;
using Vue.Models;

namespace Vue.Controllers
{
    public class OrdersController : Controller
    {
        [Route("api/[controller]/items")]
        public OrderModel Items()
        {
            var items = new List<Item>
            {
                new Item { Price = 5, Name = "Cheeseburger", ItemSubType = ItemSubType.Sandwich },
                new Item { Price = 6, Name = "Reuben", ItemSubType = ItemSubType.Sandwich },
                new Item { Price = 4, Name = "Cesear", ItemSubType = ItemSubType.Salad },
                new Item { Price = 2, Name = "Coke", ItemSubType = ItemSubType.Soda }
            };

            var model = new OrderModel();
            var categories = items.Select(x => x.ItemType).Distinct();
            foreach (var category in categories)
            {
                var categoryModel = new Category
                {
                    ItemType = category
                };
                var categoryItems = items.Where(x => x.ItemType == category);
                var subcategories = categoryItems.Select(x => x.ItemSubType).ToList().Distinct();
                foreach (var subcategory in subcategories)
                {
                    var subCategoryItems = categoryItems.Where(y => y.ItemSubType == subcategory).ToList();
                    categoryModel.Subcategories.Add(new SubCategory
                    {
                        ItemType = category,
                        ItemSubType = subcategory,
                        Items = subCategoryItems.Select(y => new ItemOrder 
                        {
                            Item = y,
                            Quantity = 0,
                            TimeRequested = DateTime.Now,
                        }).ToList()
                    });                   
                }
                model.AddCategory(categoryModel);
            }
            return model;
        }

        // [Route("api/[controller]/add")]
        // [HttpPost]
        // public bool Get(OrderModel ordermodel)
        // {
        //     var order = new Order(5)
        //     {
        //         Items = ordermodel.Categories.SelectMany(x => x.Subcategories.SelectMany(y => y.Items)).ToList()
        //     };
        //     return true;
        // }

        [Route("api/[controller]/add")]
        [HttpPost]
        public bool Get(Payload payload)
        {
            return true;
        }

        public class Payload
        {
            public int id { get; set; }
        }
    }
}