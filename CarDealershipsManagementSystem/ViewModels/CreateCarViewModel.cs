using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreateCarViewModel
    {
        public  string? DealershipId { get; set; }
        public string? EngineId { get; set; }
        public string? ModelId { get; set; }
        public string? EquipmentId { get; set; }
        public DateTime? CarProductionYear { get; set; }
        public int? CarWeight { get; set; }
        public bool? CarUsed { get; set; }
        public bool? CarCrashed { get; set; }

        public string? OrderStatus { get; set; }
        public string? OrderPaymentType { get; set; }
        public string? OrderShipmentType { get; set; }
        public double? OrderPrice { get; set; }
        public double? OrderDiscount { get; set; }

    }
}
