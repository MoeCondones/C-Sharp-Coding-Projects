using NewsLetterAppMVC.Models;
using NewsLetterAppMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewsLetterAppMVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            using (NewsletterEntities db = new NewsletterEntities())
            {
                //var signUps = db.SignUps.Where(x => x.Remove == null).ToList();
                var signUps = (from c in db.SignUps
                               where c.Remove == null
                               select c).ToList();
                var signupVms = new List<SignupVm>();
                foreach (var signup in signUps)
                {
                    var signupVm = new SignupVm();
                    signupVm.Id = signup.Id;
                    signupVm.FirstName = signup.FirstName;
                    signupVm.LastName = signup.LastName;
                    signupVm.EmailAddress = signup.EmailAddress;
                    signupVms.Add(signupVm);
                }
                return View(signupVms);
            }
        }
        public ActionResult Unsubscribe(int id)
        {
            using (NewsletterEntities db = new NewsletterEntities()) 
            {
                var signup = db.SignUps.Find(id);
                signup.Remove = DateTime.Now;
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}