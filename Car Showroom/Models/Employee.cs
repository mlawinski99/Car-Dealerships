using Car_Showroom.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Employee
    {
        public Employee()
        {
            OrderDealerEmployee = new HashSet<Order>();
            OrderServiceEmployee = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public int DealerId { get; set; }
        public ContractType ContractType { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public JobPosition JobPosition { get; set; }
        public int? ManagerId { get; set; }
        public double? Salary { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Dealer Dealer { get; set; }
        public virtual ICollection<Order> OrderDealerEmployee { get; set; }
        public virtual ICollection<Order> OrderServiceEmployee { get; set; }
    }
}
