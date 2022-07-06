using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.ViewModels
{
    public class CreateEmployeeViewModel
    {
        #region ApplicationUser Fields
        [Display(Name = "Imie")]
        public string? FirstName { get; set; }
        [Display(Name = "Nazwisko")]
        public string? LastName { get; set; }
        [Display(Name = "PESEL")]
        public string? Pesel { get; set; }
        [Display(Name = "Data urodzenia")]
        [DataType(DataType.Date)]
        public DateTime? BirthDate { get; set; }
        [Display(Name = "Email")]
        public string? Email { get; set; }
        [Display(Name = "Numer telefonu")]
        public string? PhoneNumber { get; set; }
        #endregion

        #region Address Fields
        [Display(Name = "Panstwo")]
        public string? AddressCountry { get; set; }
        [Display(Name = "Kod panstwa")]
        public string? AddressCountryCode { get; set; }
        [Display(Name = "Miasto")]
        public string? AddressCity { get; set; }
        [Display(Name = "Wojewodztwo")]
        public string? AddressDistrict { get; set; }
        [Display(Name = "Ulica")]
        public string? AddressStreet { get; set; }
        [Display(Name = "Numer domu/mieszkania")]
        public string? AddressApartmentNumber { get; set; }
        [Display(Name = "Kod pocztowy")]
        public string? AddressPostalCode { get; set; }
        #endregion

        #region Employee Fields
        [Display(Name = "Umowa")]
        public string? EmployeeContractType { get; set; }
        [Display(Name = "Stanowisko")]
        public string? EmployeeJobPosition { get; set; }
        [Display(Name = "Placa")]
        public double? EmployeeSalary { get; set; }
        [Display(Name = "Data rozpoczecia")]
        [DataType(DataType.Date)]
        public DateTime? EmployeeStartDate { get; set; }
        [Display(Name = "Data zakonczenia")]
        [DataType(DataType.Date)]
        public DateTime? EmployeeFinishDate { get; set; }
        #endregion

        #region IfManager
        [Display(Name = "Salon")]
        public string? DealershipId { get; set; }
        #endregion
    }
}
