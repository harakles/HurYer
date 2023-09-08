using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Net.WebRequestMethods;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class CaseController : Controller
    {
        public ActionResult List(int TurID)
        {
            var db = new Entities();
            var data = db.BrodcastClasses.Find(TurID);
            return View(data);
        }

        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TurID)
        {
            var db = new Entities();
            var query = CaseManager.GetList(requestModel, TurID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.BroadcastName
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add(int TurID)
        {
            var db = new Entities();
            var data = new Broadcast();
            data.BroadcastClassID = TurID;
            data.BrodcastClass = db.BrodcastClasses.Find(TurID);
            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.Broadcasts.Find(Id);
            return View("Add", data);
        }

        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(Broadcast data, List<int> Files)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            var files = db.FileGalleries.Where(x=>x.BrodcastID == data.Id).ToList();
            foreach (var x in files)
            {
                db.FileGalleries.Remove(x);
                db.SaveChanges() ;
            }
            if (Files != null && Files.Count() != 0)
            {
                foreach (var file in Files)
                {
                    var gallery = new FileGallery();
                    gallery.FileID = file;
                    gallery.BrodcastID = data.Id;
                    gallery.Deleted = false;
                    db.Entry(gallery).State = gallery.Id > 0 ? EntityState.Modified : EntityState.Added;
                    db.SaveChanges();
                }
            }
            
            return RedirectToAction("List", new { TurID = data.BroadcastClassID });
        }

        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var data = db.Broadcasts.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var db = new Entities();
            var data = new EDMX.File() { };
            if (file != null && file.ContentLength > 0)
            {
                var fotoformat = Path.GetExtension(file.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/Case/Files/" + fotoad));
                file.SaveAs(fotoyol);
                data.FilePath = "/Upload/Case/Files/" + fotoad;
                data.FileName = file.FileName;
                db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
                db.SaveChanges();
                return Json(data);
            }

            return HttpNotFound();
        }

        public ActionResult FileDelete(int Id)
        {
            var db = new Entities();
            var data = db.Files.Find(Id);
            var path = Server.MapPath(data.FilePath);
            var gallery = db.FileGalleries.Where(x => x.FileID == data.Id).FirstOrDefault();
            if (gallery != null)
            {
                db.FileGalleries.Remove(gallery);
            }
            System.IO.File.Delete(path);
            db.Files.Remove(data);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}