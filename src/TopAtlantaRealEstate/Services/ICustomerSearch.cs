using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.Services
{
    public interface ICustomerSearch
    {
        bool CustomerSearch(string name, string phone, string email);
    }
}
