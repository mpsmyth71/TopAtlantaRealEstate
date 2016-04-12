using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.Services
{
    public class CustomerSearchServices : ICustomerSearch
    {
        public bool CustomerSearch(string name, string phone, string email)
        {
            Debug.WriteLine($"Name: To: {name}, phone: {phone}, email: {email}");
            return true;
        }
    }
}
