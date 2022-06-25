﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace CarDealershipsManagementSystem.Models
{
    public partial class ApplicationUser : IdentityUser<int>
    {
        #region Constructors
        public ApplicationUser()
        {
            Address = new Address();
        }
        #endregion

        #region Fields
        public int ApplicationUserId { get; set; }
        public string? ApplicationUserFirstName { get; set; }
        public string? ApplicationUserLastName { get; set; }
        public string? ApplicationUserPesel { get; set; }
        [DataType(DataType.Date)]
        public DateTime? ApplicationUserBirthDate { get; set; }
        #endregion

        #region OneToOneRelationships
        public virtual Address Address { get; set; }
        #endregion
    }
}
