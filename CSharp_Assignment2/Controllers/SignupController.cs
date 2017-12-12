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
            ViewBag["user"] = user;
            return RedirectToAction("SuccessfullSignupView");
        }

        public IActionResult test()
        {
            var list = Submission.ReadSubmissionsFromFile(@"Models\Submissions.txt");
            var sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            foreach (var item in list)
                sb.Append(item + Environment.NewLine);
            return Content(sb.ToString());
        }
    }
}