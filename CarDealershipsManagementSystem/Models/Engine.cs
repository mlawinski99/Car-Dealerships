using System;
using System.Collections.Generic;
using System.Linq;
namespace CarDealershipsManagementSystem.Models
{
    public partial class Engine
    {
        #region Constructors
        public Engine()
        {
            Cars = new HashSet<Car>();
            Models = new HashSet<Model>();
        }
        #endregion

        #region Fields
        public int EngineId { get; set; }
        public string? EngineName { get; set; } = null!;
        public string? EngineType { get; set; } = null!;
        public int? EngineDisplacement { get; set; }
        public int? EnginePower { get; set; }
        public float? EnigneFuelConsumption { get; set; }
        public float? EnginePowerConsumption { get; set; }
        public int? EnginePrice { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Car> Cars { get; set; }
        #endregion

        #region ManyToManyRelationships
        public virtual ICollection<Model> Models { get; set; }
        #endregion
    }
}
