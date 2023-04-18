using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CarInsurance;
using CarInsurance.Models;

namespace CarInsurance.Controllers
{
    public class AdminController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();
        // GET: Admin
        public ActionResult Index()
        {
            var quotes = db.Insurees.ToList();

            return View();
        }

    }
}