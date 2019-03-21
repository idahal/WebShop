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

        internal void Add(PlaceOrder order)
        {
            throw new NotImplementedException();
        }


        internal void Add()
        {
            throw new NotImplementedException();
        }

        //public void Add(PlaceOrder order)
        //{
        //    using (var connection = new SqlConnection(this.connectionString))
        //    {
        //        var orderItem = connection.Execute("INSERT INTO PlaceOrder (CostumerName, CostumerLastName, CostumerAddress, CostumerZipcode, CostumerCity) VALUES(@title, @content, @quantity, @price)", order);

        //    }
        //}
    }
}
