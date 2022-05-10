using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class ModelsTrims
    {
        public int ModelId { get; set; }
        public int TrimId { get; set; }

        public virtual Model Model { get; set; }
        public virtual Trim Trim { get; set; }
    }
}
