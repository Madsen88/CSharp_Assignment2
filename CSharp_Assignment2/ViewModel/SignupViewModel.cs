using System;
using System.ComponentModel.DataAnnotations;

namespace CSharp_Assignment2.ViewModel
{
    public class SignupViewModel
    {
        [Required]
        [MinLength(1)]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [MinLength(1)]
        [Display(Name = "Surname")]
        public string Surname { get; set; }

        [Required]
        [MinLength(5)]
        [MaxLength(100)]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Phone Number")]
        public int Phonenumber { get; set; }

        [Required]
        [Display(Name = "Date Of Birth")]
        public DateTime DOB { get; set; }

        [Required]
        [Display(Name = "Serial Number")]
        public int SerialNumber { get; set; }
    }
}