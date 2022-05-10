using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Details
    {
        public Details()
        {
            Car = new HashSet<Car>();
        }

        public int Id { get; set; }
        public byte[] Photo { get; set; }
        public DateTime? ProductionYear { get; set; }
        public int? Weight { get; set; }
        public bool? Used { get; set; }
        public bool? Crashed { get; set; }

        public virtual ICollection<Car> Car { get; set; }
    }
}
