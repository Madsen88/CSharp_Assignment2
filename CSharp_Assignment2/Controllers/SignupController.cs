using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Assignment2.Models;
using CSharp_Assignment2.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Text;

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

        public IActionResult test()
        {
            var list = Submission.ReadSubmissionsFromFile(@"Models\Submissions.txt");
            StringBuilder sb = new StringBuilder();
            sb.Append(Environment.NewLine);
            foreach (Submission item in list)
            {
                sb.Append(item.ToString()+ Environment.NewLine);
            }
            return Content(sb.ToString());
        }
    }
}