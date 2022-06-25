using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateCarViewModel
    {
        public int DealerId { get; set; }
        public int OrderId { get; set; }
        public int ModelId { get; set; }
        public int EquipmentId { get; set; }
        public int EngineId { get; set; }

        public DateTime? CarProductionYear { get; set; }
        public int? CarWeight { get; set; }
        public bool? CarUsed { get; set; }
        public bool? CarCrashed { get; set; }

        public string? OrderStatus { get; set; }
        public string? OrderPaymentType { get; set; }
        public string? OrderShipmentType { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderSubmissionDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? OrderFinalizationDate { get; set; }
        public double? OrderPrice { get; set; }
        public double? OrderDiscount { get; set; }

    }
}
