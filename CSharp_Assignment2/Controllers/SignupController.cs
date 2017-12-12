using System;
using System.Text;
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
        public IActionResult index(SignupModel signup)
        {
            if (!ModelState.IsValid)
                return View();
            
            var user = new Submission(signup.FirstName, signup.Surname, signup.Email, signup.Phonenumber, signup.DOB,
                signup.SerialNumber);
            user.SaveSubmissionToFile(user);
            return RedirectToAction("SuccesfullSignup");
        }

        public IActionResult SuccesfullSignup()
        {
            return View();
        }
    }
}