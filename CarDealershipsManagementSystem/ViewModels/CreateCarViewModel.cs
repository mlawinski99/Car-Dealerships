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
        public  Dealership Dealership { get; set; }
        public  Engine Engine { get; set; }
        public  Model Model { get; set; }
        public  Equipment Equipment { get; set; }
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
