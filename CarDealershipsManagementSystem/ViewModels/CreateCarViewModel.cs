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
        public  int DealershipId { get; set; }
        public int EngineId { get; set; }
        public int ModelId { get; set; }
        public int EquipmentId { get; set; }
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
