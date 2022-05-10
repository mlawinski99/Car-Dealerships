using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class TrimsOptions
    {
        public int OptionId { get; set; }
        public int TrimId { get; set; }

        public virtual Option Option { get; set; }
        public virtual Trim Trim { get; set; }
    }
}
