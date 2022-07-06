using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreateEquipmentViewModel
    {
        [Display(Name = "Nazwa")]
        public string EquipmentName { get; set; }
        [Display(Name = "Cena")]
        public int EquipmentPrice { get; set; }
        [Display(Name = "Opcje")]
        public List<string> OptionIdList { get; set; }
    }
}
