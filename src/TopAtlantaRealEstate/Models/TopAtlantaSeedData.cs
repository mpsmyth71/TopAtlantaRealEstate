using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.Models
{
    public class TopAtlantaSeedData
    {
        private readonly TopAtlantaContext _context;

        public TopAtlantaSeedData(TopAtlantaContext context)
        {

            _context = context;
        }
        public void EnsureSeedData()
        {

            if (!_context.Customers.Any())
            {
                //Add new Data
                var customer1 = new Customer()
                {
                    FirstName = "Mike",
                    LastName = "Smyth",
                    Gender = "Male",
                    Company = "CTS",
                    JobTitle = "Director of Technology",
                    MiddleName = "Patrick",
                    Birthday = DateTime.Parse("10/01/1971"),
                    Emails = new List<Email>()
                    {
                        new Email() {EmailAddress = "mpsmyth71@hotmail.com", IsPrimary = true},
                        new Email() {EmailAddress = "mspmyth71@gmail.com", IsPrimary = false }
                    },
                    Phones = new List<Phone>()
                    {
                        new Phone() {PhoneNumber = "7703296183", PhoneType="mobile"},
                        new Phone() {PhoneNumber = "4048417585", PhoneType="home" }
                    }
                };

                _context.Customers.Add(customer1);
                _context.Emails.AddRange(customer1.Emails);
                _context.Phones.AddRange(customer1.Phones);

                var customer2 = new Customer()
                {
                    FirstName = "Karen",
                    LastName = "Smyth",
                    Gender = "Female",
                    Company = "Keller Williams",
                    JobTitle = "Agent",
                    MiddleName = "Habra",
                    Birthday = DateTime.Parse("12/13/1971"),
                    Emails = new List<Email>()
                    {
                        new Email() { EmailAddress = "Karen@KarenSmyth.com", IsPrimary = true},
                        new Email() {EmailAddress = "Karen@TopAtlantaRealEstate.com", IsPrimary = false }
                    },
                    Phones = new List<Phone>()
                    {
                        new Phone() {PhoneNumber = "4042341196", PhoneType="mobile"},
                        new Phone() {PhoneNumber = "4048417585", PhoneType="home" }
                    }
                };

                _context.Customers.Add(customer2);
                _context.Emails.AddRange(customer2.Emails);
                _context.Phones.AddRange(customer2.Phones);

                _context.SaveChanges();
            }
        }
    }
}
