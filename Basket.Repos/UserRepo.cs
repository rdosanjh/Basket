using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Repos
{
    public class UserRepo : IUserRepo
    {
        private readonly Dictionary<string, Guid> store = new Dictionary<string, Guid>();
        // create a user if one doesnt exist in real life this would probably user jwt based auth
        public Guid getIdFromApiKey(string apiKey)
        {
            if (!store.ContainsKey(apiKey))
            {
                store[apiKey] = Guid.NewGuid();
                return store[apiKey];
            }
            return store[apiKey];
        }
    }
}
