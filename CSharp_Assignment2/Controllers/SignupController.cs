using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Assignment2.Models;
using CSharp_Assignment2.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace CSharp_Assignment2.Controllers
{
    public class SignupController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult index(SignupViewModel signup)
        {
            if (!ModelState.IsValid)
            {
                // Implement SerialKode Validation
                return View();
            }
            var user = new Submission(signup.FirstName, signup.Surname, signup.Email, signup.Phonenumber, signup.DOB, signup.SerialNumber);

            return Content(user.ToString());
        }
    }
}