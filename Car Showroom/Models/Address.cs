using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Address
    {
        public Address()
        {
            ApplicationUser = new HashSet<ApplicationUser>();
            Dealer = new HashSet<Dealer>();
        }

        public int Id { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Street { get; set; }
        public string ApartmentNumber { get; set; }
        public string PostalCode { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUser { get; set; }
        public virtual ICollection<Dealer> Dealer { get; set; }
    }
}
