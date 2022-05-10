using Car_Showroom.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Customer
    {
        public Customer()
        {
            Order = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public CustomerType CustomerType { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public virtual ICollection<Order> Order { get; set; }
    }
}
