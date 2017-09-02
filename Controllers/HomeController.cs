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
            return new HomeModel {
                ActiveParties = new List<Party>
                {
                    new Party
                    { 
                        Table = new Table { Number = 1 },
                        Orders = new List<Order>
                        {
                            new Order 
                            {
                                Items = new List<ItemOrder>
                                {
                                    new ItemOrder 
                                    { 
                                        TimeRequested = DateTime.Now.AddMinutes(-5),
                                        Item = new Item { Price = 2.5, ItemType = ItemType.Drink, Name = "Coke" }
                                    }
                                }
                            }
                        }
                    },
                    new Party
                    { 
                        Table = new Table { Number = 3 }
                    }
                }
            };
        }
    }
}