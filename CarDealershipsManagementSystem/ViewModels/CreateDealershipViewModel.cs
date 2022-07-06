using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreateDealershipViewModel
    {
        #region Address Fields
        [Display(Name = "Ulica")]
        public string AddressStreet { get; set; }
        [Display(Name = "Numer Budynku")]
        public string AddressApartmentNumber { get; set; }
        [Display(Name = "Kod Pocztowy")]
        public string AddressPostalCode { get; set; }
        [Display(Name = "Miasto")]
        public string AddressCity { get; set; }
        [Display(Name = "Wojewodztwo")]
        public string AddressDistrict { get; set; }
        [Display(Name = "Panstwo")]
        public string AddressCountry { get; set; }
        [Display(Name = "Kod Panstwa")]
        public string AddressCountryCode { get; set; }
        #endregion

        #region Dealership Fields
        [Display(Name = "Nazwa Salonu")]
        public string Name { get; set; }
        [Display(Name = "Maksymalna liczba samochodow")]
        public int? MaxCarsNumber { get; set; }
        #endregion
    }
}
