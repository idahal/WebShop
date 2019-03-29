using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;


namespace WebShop.Repositories
{
    public class PlaceOrderRepository
    {
        private readonly string connectionString;
        public PlaceOrderRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<PlaceOrder> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var orderItems = connection.Query<PlaceOrder>("SELECT * FROM PlaceOrder").ToList();
                return orderItems;
            }

        }

      
        public PlaceOrder Get(Guid guid)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<PlaceOrder>("SELECT * FROM PlaceOrder WHERE Id = @guid", new { guid });
            }

        }


        public void Add(PlaceOrder placeOrder)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute("INSERT INTO PlaceOrder (Name, LastName, Address, Zipcode, City, CartGuid) VALUES(@name, @lastname, @address, @zipcode, @city, @cartguid)", placeOrder);

            }
        }
    }
}
