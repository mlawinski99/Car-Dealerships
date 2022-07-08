using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreatePDFViewModel
    {
        [DataType(DataType.Date)]
        [Display(Name = "Od")]
        public DateTime StartDate { get; set; }
        [DataType(DataType.Date)]
        [Display(Name = "Do")]
        public DateTime EndDate { get; set; }

    }
}
