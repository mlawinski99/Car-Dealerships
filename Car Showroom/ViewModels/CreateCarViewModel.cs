using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateCarViewModel
    {
        public int DetailsId { get; set; }
        public int DealerId { get; set; }
        public int OrderId { get; set; }
        public int ModelId { get; set; }
        public int TrimId { get; set; }
        public int EngineId { get; set; }

        public int? DealerEmployeeId { get; set; }
        public int? ServiceEmployeeId { get; set; }
        public OrderStatus Status { get; set; }
        public double? Price { get; set; }
        public double? Discount { get; set; }
        public PaymentType PaymentType { get; set; }
        public DateTime? SubmissionDate { get; set; }
        public DateTime? FinalizationDate { get; set; }
        public ShipmentType ShipmentType { get; set; }

        public DateTime? ProductionYear { get; set; }
        public int? Weight { get; set; }
    }
}
