using NUnit.Framework;
using WebShop.Services;
using WebShop.Repositories;
using System.Data.SqlClient;
using System.Transactions;

namespace WebShop.IntegrationTests.Services
{
    class ItemsServiceTests
    {
        private ItemsService itemsService;

        [SetUp]
        public void SetUp()
        {
            this.itemsService = new ItemsService(new ItemsRepository(
                "Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=WebShopDB;Integrated Security=True;Pooling=True"));
        }

        [Test]
        public void Get_ReturnsResultsFromDatabase()
        {
            // Act
            var results = this.itemsService.Get();
            // Assert
            Assert.That(results.Count, Is.EqualTo(7));
            Assert.That(results[1].Id, Is.EqualTo(26));
            Assert.That(results[1].Title, Is.EqualTo("Clouds in the sky"));
            Assert.That(results[1].Content, Is.EqualTo("A super nice poster of clouds in the sky."));
            Assert.That(results[1].Quantity, Is.EqualTo(5));
            Assert.That(results[1].Price, Is.EqualTo(259.0000));
            Assert.That(results[1].Image, Is.EqualTo("posterFive.jpg"));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromDatabase()
        {
            // Act
            var results = this.itemsService.Get(26);
            // Assert
            Assert.That(results.Id, Is.EqualTo(26));
        }
    }
}
