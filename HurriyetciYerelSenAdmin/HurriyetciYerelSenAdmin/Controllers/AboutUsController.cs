using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class AboutUsController : Controller
    {
        // GET: AboutUs
        public ActionResult AboutUs()
        {
            var db = new Entities();
            var data = db.AboutUs.Find(1);
            return View(data);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult AboutUs(AboutU data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("AboutUs");
        }
    }
}