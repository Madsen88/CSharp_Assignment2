using System;
using System.ComponentModel.DataAnnotations;
using CSharp_Assignment2.Models;
using Microsoft.Azure.KeyVault.Models;

namespace CSharp_Assignment2.ViewModel
{
    public class SignupModel
    {
        [Required(ErrorMessage = "Please insert your First name")]
        [MinLength(1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Please insert your Last name")]
        [MinLength(1)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Please insert your E-mail address")]
        [MinLength(5)]
        [MaxLength(100)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Please insert your Phone number (8 digits)")]
        [MinLength(8, ErrorMessage = "Must be Min 8 digits")]
        [Display(Name = "Phone Number")]
        public string Phonenumber { get; set; }

        [Required(ErrorMessage = "You need insert your date of birth")]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "You need to have a valid Serialkey")]
        [MinLength(6, ErrorMessage = "Serialkey is not a valid length")]
        [Display(Name = "Serial Number")]
        [SerialkeyValidation(ErrorMessage = "Serialkey is not valid")]
        public string SerialNumber { get; set; }
    }
}