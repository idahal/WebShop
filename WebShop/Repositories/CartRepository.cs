using System;
using System.Collections.Generic;
using System.Linq;
using WebShop.Models;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Dapper;

namespace WebShop.Repositories
{
    public class CartRepository
    {
        private readonly string connectionString;
        public CartRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Cart> Get(Guid guid)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItems = connection.Query<Cart>(
                    @"SELECT title, image, cart.price FROM Cart 
                        LEFT JOIN Items ON cart.itemid = Items.Id 
                        WHERE CartGuid = @guid", new { guid }).ToList();

                return cartItems;
            }

        }



           public void Add(int id, Guid guid, int price)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {

                var shopItem = connection.Execute($"INSERT INTO Cart (ItemId, CartGuid, price) VALUES({id}, '{guid}', {price})");

            }
        }
    }
}
