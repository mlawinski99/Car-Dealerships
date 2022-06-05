using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateCarViewModel
    {
        public int DetailsId { get; set; }
        public int? DealerId { get; set; }
        public int? OrderId { get; set; }
        public int ModelId { get; set; }
        public int TrimId { get; set; }
        public int EngineId { get; set; }

        public DateTime? ProductionYear { get; set; }
        public int? Weight { get; set; }
        public bool? Used { get; set; }
        public bool? Crashed { get; set; }
    }
}
