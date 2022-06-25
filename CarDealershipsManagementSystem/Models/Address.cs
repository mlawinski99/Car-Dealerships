using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Address
    {
        #region Costructors
        public Address()
        {
        }
        #endregion

        #region Fields
        public int AddressId { get; set; }
        public string? AddressCountry { get; set; }
        public string? AddressCountryCode { get; set; }
        public string? AddressCity { get; set; }
        public string? AddressDistrict { get; set; }
        public string? AddressStreet { get; set; }
        public string? AddressApartmentNumber { get; set; }
        public string? AddressPostalCode { get; set; }
        #endregion
    }
}
