using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basket.Extentions;
using Basket.Models;
using Basket.Repos;
using Microsoft.AspNetCore.Mvc;

namespace Basket.Controllers
{
    [Route("api/[controller]")]
    public class OrdersController : Controller
    {
        private readonly IBasketRepo _basketRepo;
        public OrdersController(IBasketRepo basketRepo)
        {
            _basketRepo = basketRepo;
        }

        [HttpGet]
        public IEnumerable<Order> Get()
        {
            var userId = HttpContext.GetUserId();
            return _basketRepo.GetBasket(userId);
        }

        [HttpPost]
        public void Post([FromBody]Order order)
        {
            var userId = HttpContext.GetUserId();
            _basketRepo.AddToBasket(userId, order.Item, order.Quantity);
        }

        [HttpPut("{id}")]
        public void Put(Guid id, [FromBody]Order order)
        {
            var userId = HttpContext.GetUserId();
            _basketRepo.UpdateQuantity(userId, order.Item, order.Quantity);
        }

        [HttpDelete("{id}")]
        public void Delete(Guid id)
        {
            var userId = HttpContext.GetUserId();
            _basketRepo.RemoveFromBasket(userId, new Item { Id = id });
        }

        [HttpDelete]
        public void Delete()
        {
            var userId = HttpContext.GetUserId();
            _basketRepo.ClearBasket(userId);
        }
    }
}
