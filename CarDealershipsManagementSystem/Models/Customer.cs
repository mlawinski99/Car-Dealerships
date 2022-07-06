using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Customer
    {
        #region Constructors
        public Customer()
        {
            ApplicationUser = new();
        }
        #endregion

        #region Fields
        public int CustomerId { get; set; }
        public string? CustomerType { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual ApplicationUser ApplicationUser { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}
