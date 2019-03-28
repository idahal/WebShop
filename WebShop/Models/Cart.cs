using System;
using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Cart
    {
        public string Title { get; set; }

        public int Price { get; set; }

        public string Image { get; set; }

    }
}
