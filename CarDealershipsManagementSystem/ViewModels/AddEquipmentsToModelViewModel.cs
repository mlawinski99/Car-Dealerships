using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class AddEquipmentsToModelViewModel
    {
        [Display(Name = "Model")]
        public string ModelId { get; set; }

        [Display(Name = "Wersje Wyposazeniowe")]
        public List<string> EquipmentIdList { get; set; }
    }
}
