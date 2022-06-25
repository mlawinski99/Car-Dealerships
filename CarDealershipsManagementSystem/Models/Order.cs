using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Order
    {
        #region Constructors
        public Order()
        {
            Customer = new();
            DealershipEmployee = new();
            ServiceEmployee = new();
            Cars = new HashSet<Car>();
            Options = new HashSet<Option>();
        }
        #endregion

        #region Fields
        public int OrderId { get; set; }
        public string? OrderStatus { get; set; }
        public string? OrderPaymentType { get; set; }
        public string? OrderShipmentType { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderSubmissionDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderFinalizationDate { get; set; }
        public double? OrderPrice { get; set; }
        public double? OrderDiscount { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual Customer Customer { get; set; }
        public virtual Employee DealershipEmployee { get; set; }
        public virtual Employee ServiceEmployee { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Car> Cars { get; set; }
        #endregion

        #region ManyToManyRelationships
        public virtual ICollection<Option> Options { get; set; }
        #endregion
    }
}
