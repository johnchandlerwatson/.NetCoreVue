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
            return new CheckoutModel {
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
                        }
                    },
                    new Party 
                    {
                        Id = Guid.NewGuid(),
                        Table = new Table 
                        {
                            Number = 2
                        }
                    } 
                }
            };
        }

        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
