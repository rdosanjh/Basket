using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Basket.Models;
using RestSharp;

namespace Basket.Client
{
    public class BasketClient : IBasketClient
    {
        private string baseUrl;
        private RestClient client;
        private string apikey;

        public BasketClient(string url, string key)
        {
            baseUrl = url;
            client = new RestClient(url);
            client.AddDefaultHeader("Authorization", key);
            apikey = key;
        }

        public async Task AddToBasket(Order order)
        {
            var request = new RestRequest("Orders", Method.POST);
            request.AddBody(order);
            await client.ExecuteTaskAsync(request);
        }

        public async Task ClearBasket()
        {
            var request = new RestRequest("Orders", Method.DELETE);
            await client.ExecuteTaskAsync(request);
        }

        public async Task<IEnumerable<Order>> GetBasket()
        {
            var request = new RestRequest("Orders", Method.GET);
            return (await client.ExecuteGetTaskAsync<IEnumerable<Order>>(request)).Data;
        }

        public async Task RemoveFromBasket(Guid itemId)
        {
            var request = new RestRequest($"Orders/{itemId}", Method.DELETE);
            await client.ExecuteTaskAsync(request);
        }

        public async Task UpdateQuantity(Order order)
        {
            var request = new RestRequest($"Orders/{order.Item.Id}", Method.PUT);
            await client.ExecuteTaskAsync(request);

        }
    }
}
