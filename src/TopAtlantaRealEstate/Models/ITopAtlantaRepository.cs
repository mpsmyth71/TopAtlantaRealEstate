using System.Collections.Generic;

namespace TopAtlantaRealEstate.Models
{
    public interface ITopAtlantaRepository
    {
        IEnumerable<Customer> GetAllCustomers();
        Customer GetCustomerById(int customerId);
        void AddCustomer(Customer newCustomer);
        bool SaveAll();
        Customer GetPhoneByCustomerId(int customerId);
        Customer GetEmailByCustomerId(int customerId);
        void addPhone(int customerId, Phone newPhone);
        void addEmail(int customerId, Email newEmail);
    }
}