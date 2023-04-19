using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarInsurance.Models;
using CarInsurance.ViewModels;

namespace CarInsurance.Controllers
{
    public class InsureeController : Controller
    {
        private InsuranceEntities db = new InsuranceEntities();

        // GET: Insuree
        public ActionResult Index()
        {
            return View(db.Insurees.ToList());
        }

        // GET: Insuree/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // GET: Insuree/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Insuree/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                insuree.Quote = 50m;
                var age = DateTime.Today.Year - insuree.DateOfBirth.Year;


                if (age <= 18)
                {
                    insuree.Quote += 100m;
                }
                else if (age > 18 && age < 26)
                {
                    insuree.Quote += 50m;
                }
                else if (age > 25)
                {
                    insuree.Quote += 25m;
                }

                if (insuree.CarYear < 2000)
                {
                    insuree.Quote += 25m;
                }
                else if (insuree.CarYear > 2015)
                {
                    insuree.Quote += 25m;
                }

                if(insuree.CarMake == "porsche".ToLower())
                {
                    insuree.Quote += 25m;
                }
                else if (insuree.CarMake == "porsche".ToLower() && insuree.CarModel == "911 carrera.".ToLower())
                {
                    insuree.Quote += 25m;
                }

                insuree.Quote += 10m * insuree.SpeedingTickets;

                if (insuree.DUI == true)
                {
                    insuree.Quote *= 1.25m;
                }

                if (insuree.CoverageType == true)
                {
                    insuree.Quote *= 1.5m;
                }

                db.Insurees.Add(insuree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(insuree);
        }

        // GET: Insuree/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,DateOfBirth,CarYear,CarMake,CarModel,DUI,SpeedingTickets,CoverageType,Quote")] Insuree insuree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(insuree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(insuree);
        }

        // GET: Insuree/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Insuree insuree = db.Insurees.Find(id);
            if (insuree == null)
            {
                return HttpNotFound();
            }
            return View(insuree);
        }

        // POST: Insuree/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Insuree insuree = db.Insurees.Find(id);
            db.Insurees.Remove(insuree);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Admin()
        {
            var adminList = new List<AdminVm>();
            using (InsuranceEntities db = new InsuranceEntities())
            {
                var quotes = (from insuree in db.Insurees
                              select new { insuree.FirstName, insuree.LastName, insuree.EmailAddress, insuree.Quote }).ToList();

                foreach (var quote in quotes)
                {
                    var admin = new AdminVm
                    {
                        FirstName = quote.FirstName,
                        LastName = quote.LastName,
                        EmailAddress = quote.EmailAddress,
                        Quote = (decimal)quote.Quote
                    };
                    adminList.Add(admin);
                }
            }
            return View(adminList);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
