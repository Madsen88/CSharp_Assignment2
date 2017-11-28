using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Assignment2.ViewModel
{
    public class SignupViewModel
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
        [Range(10000000,99999999)]
        [Display(Name = "Phone Number")]
        public int Phonenumber { get; set; }

        [Required(ErrorMessage = "You need insert your date of birth")]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required(ErrorMessage = "You need to have a valid Serialkey")]
        [Range(000000, 999999, ErrorMessage = "That Serialkey is not valid length")]
        [Display(Name = "Serial Number")]
        public int SerialNumber { get; set; }
    }
}