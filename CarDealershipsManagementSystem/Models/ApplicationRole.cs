using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class ApplicationRole : IdentityRole<int>
    {
        #region Constructors
        public ApplicationRole()
        {
        }
        #endregion

        #region Fields
        public int ApplicationRoleId { get; set; }
        public string? ApplicationRoleDescription { set; get; }
        #endregion
    }
}
