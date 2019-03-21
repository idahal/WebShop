using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.Models
{
    public class PlaceOrder
    {
        public string CartId { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public string CustomerLastname { get; set; }

        public string CustomerAdress { get; set; }

        public string CustomerAddress { get; set; }

        public string CustomerZipcode { get; set; }

        public string CustomerCity { get; set; }

    }
}
