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

        public PlaceOrder Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var orderItems = connection.QuerySingleOrDefault<PlaceOrder>("SELECT * FROM orderItems WHERE Id = @id", new { id });
                return orderItems;
            }
        }


        public void Add(PlaceOrder placeorder)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var orderItem = connection.Execute("INSERT INTO PlaceOrder (Name, LastName, Address, Zipcode, City) VALUES(@name, $lastname, @address, $zipcode, @city)", placeorder);

            }
        }
    }
}
