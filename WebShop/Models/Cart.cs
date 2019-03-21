using System.ComponentModel.DataAnnotations;

namespace WebShop.Models
{
    public class Cart
    {

        public string Id { get; set; }

        [Key]
        public string CartId { get; set; }

        public string Title { get; set; }

        public int Quantity { get; set; }

        public int Price { get; set; }

    }
}
