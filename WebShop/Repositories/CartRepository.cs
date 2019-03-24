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

        public List<Cart> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItems = connection.Query<Cart>("SELECT * FROM Cart").ToList();
                return cartItems;
            }

        }

        public Cart Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var cartItems = connection.QuerySingleOrDefault<Cart>("SELECT * FROM Cart WHERE Id = @id", new { id });
                return cartItems;
            }
        }

           public void Add(int id, Guid guid)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {

                var shopItem = connection.Execute($"INSERT INTO Cart (ItemId, CartGuid) VALUES({id}, '{guid}')");

            }
        }
    }
}
