using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class ServiceEmployeeManageOrderViewModel
    {
        [Display(Name = "Nazwa")]
        public string ModelName { get; set; }
        [Display(Name = "Typ")]
        public string ModelType { get; set; }
        [Display(Name = "Cena")]
        public int ModelPrice { get; set; }
        [Display(Name = "Silniki")]
        public List<string> EngineIdList { get; set; }
        [Display(Name = "Wersje Wyposażeniowe")]
        public List<string> EquipmentIdList { get; set; }
    }
}
