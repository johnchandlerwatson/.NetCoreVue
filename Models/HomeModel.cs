using System;
using System.Collections.Generic;
using Vue.Domain;

namespace Vue.Models
{
    public class HomeModel
    {
        public User User { get; set; }
        public List<Party> ActiveParties { get; set; }
    }
}