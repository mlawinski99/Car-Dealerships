using Microsoft.AspNetCore.Http;
using Microsoft.DotNet.Scaffolding.Shared.Project;
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
        public ModelType Type { get; set; }
        public int EngineId { get; set; }
        public int TrimId { get; set; }
    }
}
