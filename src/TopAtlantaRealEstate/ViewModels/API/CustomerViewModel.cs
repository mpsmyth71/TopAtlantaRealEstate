using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TopAtlantaRealEstate.ViewModels.API
{
    public class CustomerViewModel
    {
        public int CustomerId { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(255, MinimumLength = 3)]
        public string LastName { get; set; }
        [StringLength(255, MinimumLength = 3)]
        public string MiddleName { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string Gender { get; set; }
        [StringLength(255, MinimumLength = 3)]
        public string Company { get; set; }
        public DateTime Birthday { get; set; }
        [StringLength(255, MinimumLength = 3)]
        public string JobTitle { get; set; }

        public IEnumerable<PhoneViewModel> Phones { get; set; }
        public IEnumerable<EmailViewModel> Emails { get; set; }
    }
}
