using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Dealer
    {
        public Dealer()
        {
            Car = new HashSet<Car>();
            Employee = new HashSet<Employee>();
        }

        public int Id { get; set; }
        public int AddressId { get; set; }
        public string Name { get; set; }
        public int? MaxCarsNumber { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
