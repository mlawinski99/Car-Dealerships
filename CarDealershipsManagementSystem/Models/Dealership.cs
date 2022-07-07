using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Dealership
    {
        #region Constructors
        public Dealership()
        {
            Address = new();
            Cars = new HashSet<Car>();
            Employees = new HashSet<Employee>();
            Orders = new HashSet<Order>();
        }
        #endregion

        #region Fields
        public int DealershipId { get; set; }
        public string? DealershipName { get; set; }
        public int? DealershipMaxCarsNumber { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual Address Address { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Employee> Employees { get; set; }
        public virtual ICollection<Car> Cars { get; set; }
        public virtual ICollection<Order> Orders { get; set; }

        #endregion
    }
}
