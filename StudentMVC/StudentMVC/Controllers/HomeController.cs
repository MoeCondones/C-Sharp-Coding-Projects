using StudentsMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentsMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contact page - Academy of Learning";

            return View();
        }
        public ActionResult Instructor(int id=0)
        {
            ViewBag.Id = id;
            Instructor DayTimeInstructor = new Instructor
            {
                Id = 1,
                fName = "erik",
                lName = "gross"
            };
            return View(DayTimeInstructor);
        }
        public ActionResult Instructors()
        {
            List<Instructor> instructors = new List<Instructor>()
            {
                new Instructor
                {
                    Id = 1,
                    fName = "rick",
                    lName = "Adams"
                },
                new Instructor
                {
                    Id = 2,
                    fName = "rock",
                    lName = "boa"
                },
                new Instructor
                {
                    Id = 3,
                    fName = "shay",
                    lName = "Addy"
                }
            };
            return View(instructors);
        }
    }
}