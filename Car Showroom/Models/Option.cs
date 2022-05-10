using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Option
    {
        public Option()
        {
            OrdersOptions = new HashSet<OrdersOptions>();
            TrimsOptions = new HashSet<TrimsOptions>();
        }

        public int Id { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public virtual ICollection<OrdersOptions> OrdersOptions { get; set; }
        public virtual ICollection<TrimsOptions> TrimsOptions { get; set; }
    }
}
