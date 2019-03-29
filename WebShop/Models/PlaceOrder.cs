using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class PlaceOrder
    {
        public int OrderId { get; set; }

        public string Name { get; set; }

        public string Lastname { get; set; }

        public string Address { get; set; }

        public string Zipcode { get; set; }

        public string City { get; set; }

        public string CartGuid { get; set; }

    }
}
