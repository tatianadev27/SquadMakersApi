using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Proxy
{
    public interface IJokeApiProxy
    {
        Task<string> GetAsync(string apiUrl);
    }

}
