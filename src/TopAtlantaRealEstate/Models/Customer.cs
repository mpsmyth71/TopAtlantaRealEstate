using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string Gender { get; set; }
        public string Company { get; set; }
        public DateTime Birthday { get; set; }
        public string JobTitle { get; set; }
        public ICollection<Email> Emails { get; set; }
        public ICollection<Phone> Phones { get; set; }
    }
}
