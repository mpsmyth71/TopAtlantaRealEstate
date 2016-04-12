using Microsoft.Data.Entity;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.Models
{
    public class TopAtlantaRepository : ITopAtlantaRepository
    {
        private TopAtlantaContext _context;
        private ILogger<TopAtlantaRepository> _logger;

        public TopAtlantaRepository(TopAtlantaContext context, ILogger<TopAtlantaRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void AddCustomer(Customer newCustomer)
        {
            _context.Add(newCustomer);
        }

        public void addEmail(int customerId, Email newEmail)
        {
            var customer = GetCustomerById(customerId);
            customer.Emails.Add(newEmail);
            _context.Customers.Update(customer);
        }

        public void addPhone(int customerId, Phone newPhone)
        {
            var customer = GetCustomerById(customerId);
            customer.Phones.Add(newPhone);
            _context.Customers.Update(customer);
        }

        public IEnumerable<Customer> GetAllCustomers()
        {
            try
            {
                return _context.Customers
                .Include(t => t.Emails)
                .Include(t => t.Phones)
                .OrderBy(t => t.LastName)
                .ToList();
            }
            catch (Exception ex)
            {

                _logger.LogError("Error occurred while returning Customers", ex);
                return null;
            }
            

        }

        public Customer GetCustomerById(int customerId)
        {
            var result = _context.Customers
                .Include(t => t.Emails)
                .Include(t => t.Phones)
                .Where(t => t.CustomerId == customerId)
                .FirstOrDefault();

            return result;
        }

        public Customer GetEmailByCustomerId(int customerId)
        {
            var result = _context.Customers.Include(t => t.Emails)
                .Where(t => t.CustomerId == customerId)
                .FirstOrDefault();

            return result;
        }

        public Customer GetPhoneByCustomerId(int customerId)
        {
            var result = _context.Customers.Include(t => t.Phones)
                .Where(t => t.CustomerId == customerId)
                .FirstOrDefault();

            return result;
        }

        public bool SaveAll()
        {
            return _context.SaveChanges() > 0;
        }
    }
}
