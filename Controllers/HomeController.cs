using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Vue.Domain;
using Vue.Models;

namespace Vue.Controllers
{
    
    public class HomeController : Controller
    {
        [Route("api/[controller]/validatePin/{pin}")]
        public bool ValidatePin(int pin)
        {
            return pin == 123;
        }

        [Route("api/[controller]")]
        [HttpGet]
        public HomeModel Get()
        {
            var model = new HomeModel {
                ActiveParties = new List<Party>
                {
                    new Party
                    { 
                        Waiter = new Waiter { FirstName = "Crispy", LastName = "Kreme" },
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
                                        Item = new Item { Price = 2.5, ItemSubType = ItemSubType.Soda, Name = "Coke" }
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
                                        Item = new Item { Price = 2.5, ItemSubType = ItemSubType.Soda, Name = "Sprite" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 1, ItemSubType = ItemSubType.App, Name = "Cookie" }
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
                                        Item = new Item { Price = 4, ItemSubType = ItemSubType.Soda, Name = "Beer" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-25),
                                        Item = new Item { Price = 6, ItemSubType = ItemSubType.Entree, Name = "Pizza" }
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
                                        Item = new Item { Price = 3, ItemSubType = ItemSubType.Soda, Name = "Shake" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    {
                        Waiter = new Waiter { FirstName = "Crispy", LastName = "Kreme" },
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
                                        Item = new Item { Price = 2.5, ItemSubType = ItemSubType.Soda, Name = "Dr Pepper" }
                                    },
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-11),
                                        Item = new Item { Price = 2, ItemSubType = ItemSubType.App, Name = "Fries" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Waiter = new Waiter { FirstName = "Mr", LastName = "Bill" },
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
                                        Item = new Item { Price = 5, ItemSubType = ItemSubType.Sandwich, Name = "Burger" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Waiter = new Waiter { FirstName = "Mr", LastName = "Bill" },
                        Table = new Table { Number = 4 }
                    },
                    new Party
                    { 
                        Waiter = new Waiter { FirstName = "William", LastName = "Wallace" },
                        Table = new Table { Number = 5 },
                        Orders = new List<Order>
                        {
                            new Order(1)
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-6),
                                        Item = new Item { Price = 5, ItemSubType = ItemSubType.Sandwich, Name = "Burger" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Waiter = new Waiter { FirstName = "William", LastName = "Wallace" },
                        Table = new Table { Number = 6 },
                        Orders = new List<Order>
                        {
                            new Order(1)
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-15),
                                        Item = new Item { Price = 3, ItemSubType = ItemSubType.Sandwich, Name = "Sandwich" }
                                    }
                                }
                            },
                            new Order(2)
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-17),
                                        Item = new Item { Price = 2, ItemSubType = ItemSubType.App, Name = "Pickles" }
                                    }
                                }
                            }
                        }
                    }
                }
            };
            return model;
        }
    }
}