using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateDealerViewModel
    {
        [MinLength(3, ErrorMessage = "Street can not be shorter than 3!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required!")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apartment Number is required!")]
        public string ApartmentNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PostalCode is required!")]
        public string PostalCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required!")]
        [MinLength(3, ErrorMessage = "City can not be shorter than 3!")]
        public string City { get; set; }
        public string District { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string Name { get; set; }
        public int? MaxCarsNumber { get; set; }
    }
}
