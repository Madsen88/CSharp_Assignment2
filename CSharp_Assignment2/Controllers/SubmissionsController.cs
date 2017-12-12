using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CSharp_Assignment2.Models;
using Microsoft.AspNetCore.Mvc;
using X.PagedList;

namespace CSharp_Assignment2.Controllers
{
    public class SubmissionsController : Controller
    {
        public IActionResult Index(int? page)
        {
            var Sublist = Submission.ReadSubmissionsFromFile(Submission.PATH);

            var startpage = 1;
            var submissionsPerRow = 10;

            ViewBag.submissionList = Sublist.ToPagedList(page ?? startpage, submissionsPerRow);
            return View();
        }
    }
}