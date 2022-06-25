using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.ViewModels
{
    public class CreateEmployeeViewModel
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "Email is required!")]
        [RegularExpression(@"^([a-zA-Z0-9_\-\.]+)@([a-zA-Z0-9_\-\.]+)\.([a-zA-Z]{2,5})$", ErrorMessage = "Entered email is not valid!")]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Login is required!")]
        [MinLength(5, ErrorMessage = "Login can not be shorter than 5!")]
        public string Login { get; set; }
        /*
         (?=.*[a-z])  -  at least one lowercase
         (?=.*[A-Z])  -  at least one uppercase
         (?=.*\d)     -  at least one digit
        .{6,}         -  at least 6 chars
         
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d).{6,}$", ErrorMessage = "Password must contain an uppercase letter, a lowercase letter, a number and at least 6 characters!")]
        */[Required(AllowEmptyStrings = false, ErrorMessage = "Password is required!")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "First Name is required!")]
        [MinLength(3, ErrorMessage = "First Name can not be shorter than 3!")]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Last Name is required!")]
        [MinLength(3, ErrorMessage = "Last Name can not be shorter than 3!")]
        public string LastName { get; set; }

        
        [Required(AllowEmptyStrings = false, ErrorMessage = "Phone number is required!")]
        public string PhoneNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PESEL is required!")]
        [MinLength(11, ErrorMessage = "PESEL must have 11 chars!")]
        [MaxLength(11, ErrorMessage = "PESEL must have 11 chars!")]
        public string Pesel { get; set; }
        public DateTime BirthDate { get; set; }

        [MinLength(3, ErrorMessage = "Street can not be shorter than 3!")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Street is required!")]
        public string Street { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "Apartment Number is required!")]
        public string ApartmentNumber { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "PostalCode is required!")]
        public string PostalCode { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "City is required!")]
        [MinLength(3, ErrorMessage = "City can not be shorter than 3!")]
        public string City { get; set; }

        public string District { get; set; }
        public string Country { get; set; }
        public string CountryCode { get; set; }

        //EMPLOYEE FIELDS
        public EmployeeContractTypes ContractType { get; set; }
        public DateTime? EmploymentDate { get; set; }
        public EmployeeJobPositions JobPosition { get; set; }
        public double? Salary { get; set; }
        public int DealerId { get; set; }


    }
}
