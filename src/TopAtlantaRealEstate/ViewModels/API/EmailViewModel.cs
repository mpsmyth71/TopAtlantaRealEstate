using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TopAtlantaRealEstate.ViewModels.API
{
    public class EmailViewModel
    {
        public int EmailId { get; set; }
        [Required]
        [EmailAddress]
        public string EmailAddress { get; set; }
        [Required]
        public bool IsPrimary { get; set; }
    }
}
