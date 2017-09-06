using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vue.Domain;
using Vue.Models;

namespace Vue.Controllers
{
    [Route("api/[controller]")]
    public class HomeController : Controller
    {
        // GET api/values
        [HttpGet]
        public HomeModel Get()
        {
            var model = new HomeModel {
                ActiveParties = new List<Party>
                {
                    new Party
                    { 
                        Table = new Table { Number = 1 },
                        Orders = new List<Order>
                        {
                            new Order(1) 
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 2.5, ItemType = ItemType.Drink, Name = "Coke" }
                                    }
                                }
                            },
                            new Order(2) 
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 2.5, ItemType = ItemType.Drink, Name = "Sprite" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 1, ItemType = ItemType.Food, Name = "Cookie" }
                                    }
                                }
                            },
                            new Order(3) 
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 4, ItemType = ItemType.Drink, Name = "Beer" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 6, ItemType = ItemType.Food, Name = "Pizza" }
                                    }
                                }
                            },
                            new Order(4) 
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 3, ItemType = ItemType.Drink, Name = "Shake" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Table = new Table { Number = 2 },
                        Orders = new List<Order>
                        {
                            new Order(1)
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-11),
                                        Item = new Item { Price = 2.5, ItemType = ItemType.Drink, Name = "Dr Pepper" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-11),
                                        Item = new Item { Price = 2, ItemType = ItemType.Food, Name = "Fries" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Table = new Table { Number = 3 },
                        Orders = new List<Order>
                        {
                            new Order(1)
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-6),
                                        Item = new Item { Price = 5, ItemType = ItemType.Food, Name = "Burger" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Table = new Table { Number = 4 }
                    }
                }
            };
            return model;
        }
    }
}