using System.ComponentModel.DataAnnotations;

namespace TopAtlantaRealEstate.ViewModels.API
{
    public class PhoneViewModel
    {
        
        public int PhoneId { get; set; }

        [Required]
        [Phone]
        public string PhoneNumber { get; set; }
        [Required]
        [StringLength(25, MinimumLength = 3)]
        public string PhoneType { get; set; }

    }
}