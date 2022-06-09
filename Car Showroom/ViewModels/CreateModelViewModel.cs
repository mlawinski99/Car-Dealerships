using Car_Showroom.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateModelViewModel
    {
        public string Name { get; set; }
        public IFormFile Image { get; set; }
        public CarType Type { get; set; }
        public int EngineId { get; set; }
        public int TrimId { get; set; }
    }
}
