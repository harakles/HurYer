using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class ConfederationController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        public ActionResult Getlist([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ConfederationManager.GetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Name,
                asset.PrezName
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult Add()
        {
            var data = new Confederation();
            return View(data);
        }

        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.Confederations.Find(Id);
            return View("Add",data);
        }

        [HttpPost]
        public ActionResult Add(Confederation data,HttpPostedFileBase Logo)
        {
            var db = new Entities();
            if (Logo != null)
            {
                var Logoformat = Path.GetExtension(Logo.FileName);
                var LogoAd = Guid.NewGuid() + Logoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/System/Logo/" + LogoAd));
                Logo.SaveAs(fotoyol);
                data.Logo = "/Upload/System/Logo/" + LogoAd;
            }
            else 
            {
                if (data.Logo == null)
                {
                    var inf = db.SystemInformations.Find(1);
                    data.Logo = inf.SystemLogo;
                }
            }
            var number = data.PhoneNumber[0];
            switch (number)
            {
                case '0':
                    data.PhoneNumber = "+9" + data.PhoneNumber;
                    break;
                case '5':
                    data.PhoneNumber = "+90" + data.PhoneNumber;
                    break;
            }
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var data = db.Confederations.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("List");
        }

    }
}