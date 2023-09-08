using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class SystemController : Controller
    {
        // GET: System
        public ActionResult Details(int Id)
        {
            var db = new Entities();
            var data = db.SystemInformations.Find(Id);
            return View(data);
        }

        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.SystemInformations.Find(Id);
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(SystemInformation data,HttpPostedFileBase SystemLogoFile,HttpPostedFileBase SystemIconFile)
        {
            var db = new Entities();
            if (SystemLogoFile != null)
            {
                var fotoformat = Path.GetExtension(SystemLogoFile.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/System/Logo/" + fotoad));
                SystemLogoFile.SaveAs(fotoyol);
                data.SystemLogo = "/Upload/System/Logo/" + fotoad;
            }
            if (SystemIconFile != null)
            {
                var fotoformat = Path.GetExtension(SystemIconFile.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/System/Icon/" + fotoad));
                SystemIconFile.SaveAs(fotoyol);
                data.SystemIcon = "/Upload/System/Icon/" + fotoad;
            }
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return Redirect("/System/Details?Id=1");
        }
    }
}