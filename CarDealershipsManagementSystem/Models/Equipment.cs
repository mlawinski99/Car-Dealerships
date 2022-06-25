using System;
using System.Collections.Generic;
using System.Linq;
namespace CarDealershipsManagementSystem.Models
{
    public partial class Equipment
    {
        #region Constructors
        public Equipment()
        {
            Cars = new HashSet<Car>();
            Models = new HashSet<Model>();
            Options = new HashSet<Option>();
        }
        #endregion

        #region Fields
        public int EquipmentId { get; set; }
        public string? EquipmentName { get; set; } = null!;
        public int? EquipmentPrice { get; set; }
        #endregion

        #region OneToManyRelationships
        public virtual ICollection<Car> Cars { get; set; }
        #endregion

        #region ManyToManyRelationships
        public virtual ICollection<Model> Models { get; set; }
        public virtual ICollection<Option> Options { get; set; }
        #endregion
    }
}
