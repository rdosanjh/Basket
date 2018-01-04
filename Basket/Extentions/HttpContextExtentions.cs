using Basket.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Basket.Extentions
{
    public static class HttpContextExtentions
    {
        public static Guid GetUserId(this HttpContext context)
        {
            StringValues apiKey;
            context.Request.Headers.TryGetValue("Authorization", out apiKey);
            apiKey.ToString();
            var userRepo = new UserRepo();
            return userRepo.getIdFromApiKey(apiKey.ToString());
        }

    }
}
