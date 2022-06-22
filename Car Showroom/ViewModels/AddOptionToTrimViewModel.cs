using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class AddOptionToTrimViewModel
    {
        public string TrimName { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
    }
}
