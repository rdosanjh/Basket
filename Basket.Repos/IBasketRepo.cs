using Basket.Models;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Basket.Repos
{
    public interface IBasketRepo
    {
        IEnumerable<Order> GetBasket(Guid userId);

        void AddToBasket(Guid userId, Item item, int quantity);

        void RemoveFromBasket(Guid userId, Item item);

        void UpdateQuantity(Guid userId, Item item, int quantity);

        void ClearBasket(Guid userId);
    }
}
