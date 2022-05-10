using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Trim
    {
        public Trim()
        {
            Car = new HashSet<Car>();
            ModelsTrims = new HashSet<ModelsTrims>();
            TrimsOptions = new HashSet<TrimsOptions>();
        }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<ModelsTrims> ModelsTrims { get; set; }
        public virtual ICollection<TrimsOptions> TrimsOptions { get; set; }
    }
}
