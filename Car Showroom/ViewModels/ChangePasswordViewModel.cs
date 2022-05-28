using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class ChangePasswordViewModel : IdentityUser
    {
       

            [Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Password must contain an uppercase letter, a lowercase letter, a number and at least 6 characters!")]
            [Compare("Password", ErrorMessage = "Password and New Password can not be the same!")]
            [DataType(DataType.Password)]
            public string NewPassword { get; set; }

            [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Password must contain an uppercase letter, a lowercase letter, a number and at least 6 characters!")]
            [Required(AllowEmptyStrings = false, ErrorMessage = "Confirm New Password is required!")]
            [Compare("NewPassword", ErrorMessage = "Passwords are not the same!")]
            [DataType(DataType.Password)]
            public string ConfirmNewPassword { get; set; }
        
    }
}
