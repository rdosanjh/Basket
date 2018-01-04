using System;
using System.Collections.Generic;
using System.Text;

namespace Basket.Repos
{
    public interface IUserRepo
    {
        Guid getIdFromApiKey(string apiKey);
    }
}
