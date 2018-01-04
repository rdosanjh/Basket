using Basket.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Basket.Client
{
    public interface IBasketClient
    {
        Task<IEnumerable<Order>> GetBasket();
        Task AddToBasket(Order order);
        Task RemoveFromBasket(Guid itemId);
        Task ClearBasket();
        Task UpdateQuantity(Order order);
    }
}
