using Basket.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace Basket.Repos.Tests
{
    [TestClass]
    public class BasketRepoTests
    {
        private BasketRepo repo;

        [TestInitialize]
        public void SetUp()
        {
            repo = new BasketRepo();
        }

        [TestMethod]
        public void AddingToBasketRetainsOrder()
        {
            var userId = Guid.NewGuid();
            var item = new Item() { Id = Guid.NewGuid() };
            var quantity = 1;
            repo.AddToBasket(userId, item, quantity);

            var result = repo.GetBasket(userId).FirstOrDefault();

            Assert.IsNotNull(result);
            Assert.AreEqual(result.Item.Id, item.Id);
            Assert.AreEqual(result.Quantity, quantity);
        }

        [TestMethod]
        public void UpdateItemQuanitytRetainsQuantity()
        {
            var userId = Guid.NewGuid();
            var item = new Item() { Id = Guid.NewGuid() };
            var quantity = 1;
            repo.AddToBasket(userId, item, quantity);
            var newQuantity = 5;

            repo.UpdateQuantity(userId, item, newQuantity);
            var result = repo.GetBasket(userId).FirstOrDefault();
           
            Assert.AreEqual(result.Quantity, newQuantity);
        }

        [TestMethod]
        public void ClearBasketRemovesAllItems()
        {
            var userId = Guid.NewGuid();
            var item = new Item() { Id = Guid.NewGuid() };
            var quantity = 1;
            repo.AddToBasket(userId, item, quantity);
            

            repo.ClearBasket(userId);
            var result = repo.GetBasket(userId).FirstOrDefault();

            Assert.IsNull(result);
        }

        [TestMethod]
        public void RemovingBasketRemovesOrder()
        {
            var userId = Guid.NewGuid();
            var item = new Item() { Id = Guid.NewGuid() };
            var quantity = 1;
            repo.AddToBasket(userId, item, quantity);

            repo.RemoveFromBasket(userId, item);
            var result = repo.GetBasket(userId).FirstOrDefault();

            Assert.IsNull(result);
        }
    }
}
