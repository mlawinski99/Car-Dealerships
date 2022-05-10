using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class ModelsEngines
    {
        public int EngineId { get; set; }
        public int ModelId { get; set; }

        public virtual Engine Engine { get; set; }
        public virtual Model Model { get; set; }
    }
}
