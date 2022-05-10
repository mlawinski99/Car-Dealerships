using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Car
    {
        public int Id { get; set; }
        public int DetailsId { get; set; }
        public int? DealerId { get; set; }
        public int? OrderId { get; set; }
        public int ModelId { get; set; }
        public int TrimId { get; set; }
        public int EngineId { get; set; }

        public virtual Dealer Dealer { get; set; }
        public virtual Details Details { get; set; }
        public virtual Engine Engine { get; set; }
        public virtual Model Model { get; set; }
        public virtual Order Order { get; set; }
        public virtual Trim Trim { get; set; }
    }
}
