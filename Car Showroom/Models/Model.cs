using Car_Showroom.Models;
using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace Car_Showroom.Models
{
    public partial class Model
    {
        public Model()
        {
            Car = new HashSet<Car>();
            ModelsEngines = new HashSet<ModelsEngines>();
            ModelsTrims = new HashSet<ModelsTrims>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string ImagePath { get; set; }
        public CarType Type { get; set; }

        public virtual ICollection<Car> Car { get; set; }
        public virtual ICollection<ModelsEngines> ModelsEngines { get; set; }
        public virtual ICollection<ModelsTrims> ModelsTrims { get; set; }
    }
}
