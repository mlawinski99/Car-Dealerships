using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class Employee
    {
        #region Constructors
        public Employee()
        {
            DealershipOrders = new HashSet<Order>();
            ServiceOrders = new HashSet<Order>();
            Dealership = new();
            ApplicationUser = new();
        }
        #endregion

        #region Fields
        public int EmployeeId { get; set; }
        public string? EmployeeContractType { get; set; }
        public string? EmployeeJobPosition { get; set; }
        public double? EmployeeSalary { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EmployeeStartDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? EmployeeFinishDate { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual Dealership? Dealership { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Order> DealershipOrders { get; set; }
        public virtual ICollection<Order> ServiceOrders { get; set; }
        #endregion

    }
}
