using System;
using System.Collections.Generic;
using System.Linq;
namespace CarDealershipsManagementSystem.Models
{
    public partial class Option
    {
        #region Constructors
        public Option() 
        {
            Equipments = new HashSet<Equipment>();
            Orders = new HashSet<Order>();
        }
        #endregion

        #region Fields
        public int OptionId { get; set; }
        public string? OptionName { get; set; } = null!;
        public string? OptionDescription { get; set; }
        public int? OptionPrice { get; set; }
        #endregion

        #region ManyToManyRelationships
        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
        #endregion
    }
}
