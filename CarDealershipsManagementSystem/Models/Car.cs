using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Car
    {
        #region Constructors
        public Car()
        {
            Dealership = new();
            Engine = new();
            Model = new();
            Equipment = new();
            Order = new();
        }
        #endregion

        #region Fields
        public int CarId { get; set; }
        [DataType(DataType.Date)]
        public DateTime? CarProductionYear { get; set; }
        public int? CarWeight { get; set; }
        public bool? CarUsed { get; set; }
        public bool? CarCrashed { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual Dealership Dealership { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Model Model { get; set; }
        public virtual Order Order { get; set; }
        public virtual Equipment Equipment { get; set; }
        #endregion
    }
}
