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

           
        public PlaceOrder Get(Guid guid)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                return connection.QuerySingleOrDefault<PlaceOrder>($"SELECT * FROM PlaceOrder WHERE cartguid = '{guid}'");
            }

        }


        public void Add(PlaceOrder placeOrder)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                connection.Execute($"INSERT INTO PlaceOrder (Name, LastName, Address, Zipcode, City, CartGuid) VALUES('{placeOrder.Name}', '{placeOrder.Lastname}', '{placeOrder.Address}', {placeOrder.Zipcode}, '{placeOrder.City}', '{placeOrder.RealGuid.Value}')");
            }
        }
    }
}
