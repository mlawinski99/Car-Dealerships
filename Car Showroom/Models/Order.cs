using Car_Showroom.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Order
    {
        public Order()
        {
            Car = new HashSet<Car>();
            OrdersOptions = new HashSet<OrdersOptions>();
        }

        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int? DealerEmployeeId { get; set; }
        public int? ServiceEmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public ShipmentType ShipmentType { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Employee DealerEmployee { get; set; }
        public virtual Employee ServiceEmployee { get; set; }
        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<OrdersOptions> OrdersOptions { get; set; }
    }
}
