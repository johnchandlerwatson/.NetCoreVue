using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Vue.Models;
using Vue.Domain;

namespace Vue.Controllers
{
    [Route("api/[controller]")]
    public class CheckoutController : Controller
    {
        [HttpGet]
        public CheckoutModel Get()
        {
            var model = new CheckoutModel {
                Parties = new List<Party> 
                {
                    new Party 
                    {
                        Id = Guid.NewGuid(), 
                        Table = new Table 
                        {
                            Number = 1
                        },
                        Orders = new List<Order> 
                        {
                            new Order(1)
                            { 
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder
                                    {
                                        TimeRequested = DateTime.Now.AddMinutes(-15),
                                        TimeReceived = DateTime.Now,
                                        Quantity = 2,
                                        Item = new Item 
                                        { 
                                            Name = "Cheeseburger",
                                            Price = 4.5,
                                            ItemSubType = ItemSubType.Sandwich
                                        }
                                    }
                                }
                            }
                        },
                        Discount = new Discount 
                        {
                            Name = "Old timer",
                            Percent = .1
                        }
                    },
                    new Party 
                    {
                        Id = Guid.NewGuid(), 
                        Table = new Table 
                        {
                            Number = 2
                        },
                        Orders = new List<Order> 
                        {
                            new Order(2)
                            { 
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder
                                    {
                                        TimeRequested = DateTime.Now.AddMinutes(-15),
                                        TimeReceived = DateTime.Now,
                                        Quantity = 1,
                                        Item = new Item 
                                        { 
                                            Name = "Iceberg",
                                            Price = 3,
                                            ItemSubType = ItemSubType.Salad
                                        }
                                    },
                                    new ItemOrder
                                    {
                                        TimeRequested = DateTime.Now.AddMinutes(-15),
                                        TimeReceived = DateTime.Now,
                                        Quantity = 1,
                                        Item = new Item 
                                        { 
                                            Name = "Reuben",
                                            Price = 4.75,
                                            ItemSubType = ItemSubType.Sandwich
                                        }
                                    },
                                    new ItemOrder
                                    {
                                        TimeRequested = DateTime.Now.AddMinutes(-15),
                                        TimeReceived = DateTime.Now,
                                        Quantity = 2,
                                        Item = new Item 
                                        { 
                                            Name = "Fries",
                                            Price = 2,
                                            ItemSubType = ItemSubType.App
                                        }
                                    }
                                }
                            }
                        },
                        Taxes = new List<Tax> 
                        {
                            new FederalTax
                            {
                                Percent = .05
                            }
                        }
                    } 
                }
            };
            return model;
        }

        [HttpGet("{id}")]
        [Route("api/[controller]/{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
