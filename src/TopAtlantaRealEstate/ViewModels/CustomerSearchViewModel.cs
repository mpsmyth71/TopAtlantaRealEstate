using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TopAtlantaRealEstate.Models;

namespace TopAtlantaRealEstate.ViewModels
{
    public class CustomerSearchViewModel
    {
        [Required]
        [StringLength(255, MinimumLength = 5)]
        public string Name { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        [Phone]
        public string Phone { get; set; }

        public IEnumerable<Customer> Customers { get; set; }
    }
}
