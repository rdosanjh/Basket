using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Basket.Models;

namespace Basket.Repos
{
    public class BasketRepo : IBasketRepo
    {
        private readonly Dictionary<Guid, ICollection<Order>> store = new Dictionary<Guid, ICollection<Order>>();

        public void AddToBasket(Guid userId, Item item, int quantity)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                Item = item,
                Quantity = quantity
            };
            if (!store.ContainsKey(userId))
            {
                store[userId] = new List<Order>();
            }
            store[userId].Add(order);
        }

        public void ClearBasket(Guid userId)
        {
            if (!store.ContainsKey(userId))
            {

            }
            store[userId] = new List<Order>();
        }

        public IEnumerable<Order> GetBasket(Guid userId)
        {
            if (!store.ContainsKey(userId))
            {
                return new List<Order>();
            }
            return store[userId];
        }

        public void RemoveFromBasket(Guid userId, Item item)
        {
            var toRemove = store[userId].Where(o => o.Item.Id == item.Id).SingleOrDefault();
            store[userId].Remove(toRemove);
        }

        public void UpdateQuantity(Guid userId, Item item, int quantity)
        {
            RemoveFromBasket(userId, item);
            AddToBasket(userId, item, quantity);
            
        }
    }
}
