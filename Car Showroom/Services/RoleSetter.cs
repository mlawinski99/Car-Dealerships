using Car_Showroom.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.Services
{
    public static class RoleSetter
    {
        private static readonly UserManager <ApplicationUser> userManager;
        public static async void setRole(ApplicationUser applicationUser, string roleName)
        {
            if (await userManager.IsInRoleAsync(applicationUser, roleName))
            {
                var rolesList = await userManager.GetRolesAsync(applicationUser);
                var result = await userManager.RemoveFromRolesAsync(applicationUser, rolesList);
                if (result.Succeeded)
                    await userManager.AddToRoleAsync(applicationUser, roleName);
            }
        }
    }
}
