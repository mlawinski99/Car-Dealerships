using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class AddEnginesToModelViewModel
    {
        [Display(Name = "Model")]
        public string ModelId { get; set; }

        [Display(Name = "Silniki")]
        public List<string> EngineIdList { get; set; }
    }
}
