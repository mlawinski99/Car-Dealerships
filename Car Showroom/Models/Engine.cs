using Car_Showroom.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Engine
    {
        public Engine()
        {
            Car = new HashSet<Car>();
            ModelsEngines = new HashSet<ModelsEngines>();
        }

        public int Id { get; set; }
        public EngineType Type { get; set; }
        public string Name { get; set; }
        public int? Size { get; set; }
        public int? Power { get; set; }
        public int? Price { get; set; }
        public double? FuelConsumption { get; set; }
        public double? EnergyConsumption { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<ModelsEngines> ModelsEngines { get; set; }
    }
}
