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
        public void Get_ReturnsResultsFromItemTable()
        {
            // Act
            var results = this.itemsService.Get();
            // Assert
            var givenId = 26;
            var givenTitle = "Clouds in the sky";
            var givenContent = "A super nice poster of clouds in the sky.";
            var givenQuantity = 5;
            var givenPrice = 259.0000;
            var givenImage = "posterFive.jpg";

            Assert.That(results.Count, Is.EqualTo(7));
            Assert.That(results[1].Id, Is.EqualTo(givenId));
            Assert.That(results[1].Title, Is.EqualTo(givenTitle));
            Assert.That(results[1].Content, Is.EqualTo(givenContent));
            Assert.That(results[1].Quantity, Is.EqualTo(givenQuantity));
            Assert.That(results[1].Price, Is.EqualTo(givenPrice));
            Assert.That(results[1].Image, Is.EqualTo(givenImage));
        }

        [Test]
        public void Get_GivenId_ReturnsResultFromItemTable()
        {
            // Act
            var givenId = 26;
            var results = this.itemsService.Get(givenId);
            // Assert
            Assert.That(results.Id, Is.EqualTo(givenId));
        }
    }
}
