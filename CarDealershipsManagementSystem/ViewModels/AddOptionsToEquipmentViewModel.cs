using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class AddOptionsToEquipmentViewModel
    {
        [Display(Name = "Wersja Wyposazeniowa")]
        public string EquipmentId { get; set; }

        [Display(Name = "Opcje")]
        public List<string> OptionIdList { get; set; }
    }
}
