using System;
using System.Collections.Generic;
using System.Linq;
namespace CarDealershipsManagementSystem.Models
{
    public partial class Model
    {
        #region Constructors
        public Model()
        {
            Cars = new HashSet<Car>();
            Engines = new HashSet<Engine>();
            Equipments = new HashSet<Equipment>();
        }
        #endregion

        #region Fields
        public int ModelId { get; set; }
        public string? ModelName { get; set; } = null!;
        public string? ModelType { get; set; } = null!;
        public string? ModelImagePath { get; set; }
        public int? ModelPrice { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Car> Cars { get; set; }
        #endregion

        #region ManyToManyRelationships
        public virtual ICollection<Engine> Engines { get; set; }
        public virtual ICollection<Equipment> Equipments { get; set; }
        #endregion
    }
}
