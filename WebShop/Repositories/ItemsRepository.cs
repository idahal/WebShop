using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using WebShop.Models;

namespace WebShop.Repositories
{
    public class ItemsRepository
    {

        private readonly string connectionString;
        public ItemsRepository(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public List<Items> Get()
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var items = connection.Query<Items>("SELECT * FROM Items").ToList();
                return items;
            }

        }

   
        public Items Get(int id)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var items = connection.QuerySingleOrDefault<Items>("SELECT * FROM Items WHERE Id = @id", new { id });
                return items;
            }
        }

        internal void Add()
        {
            throw new NotImplementedException();
        }

        public void Add(Items items)
        {
            using (var connection = new SqlConnection(this.connectionString))
            {
                var shopItem = connection.Execute("INSERT INTO Items (Title, Content, Quantity, Price, Image) VALUES(@title, @content, @quantity, @price, @image)", items);

            }
        }
    }
}
