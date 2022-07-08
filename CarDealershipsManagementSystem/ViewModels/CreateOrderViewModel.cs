using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreateOrderViewModel
    {
        public string? EngineId { get; set; }
        public string? ModelId { get; set; }
        public string? EquipmentId { get; set; }
        public string? OrderPaymentType { get; set; }
        public string? OrderShipmentType { get; set; }
        public string? OrderPrice { get; set; }

    }
}
