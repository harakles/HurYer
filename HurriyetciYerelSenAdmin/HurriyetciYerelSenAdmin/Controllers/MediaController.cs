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
using HurriyetciYerelSenAdmin.Models;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class MediaController : Controller
    {
        public ActionResult List(int TurID) { var db = new Entities(); var data = db.MediaTypes.Find(TurID); return View(data); }
        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string TurID)
        {
            var db = new Entities();
            var query = MediaManager.GetList(requestModel, TurID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                MediaDate = asset.MediaDate.HasValue? asset.MediaDate.Value.ToString("dd-MM-yyyy"): "", 
                asset.MediaTittle,
                asset.MediaCoverPhoto,
                MediaType = asset.MediaType.TypeName
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add(int TurID)
        {
            var db = new Entities();
            var inf = db.SystemInformations.FirstOrDefault();
            var MediaTypes = db.MediaTypes.ToList();
            ViewBag.MediaDropdowns = new SelectList(MediaTypes, "Id", "TypeName");
            var x = db.MediaTypes.Find(TurID);
            var Media = new SystemMedia() { MediaTypeID = TurID , MediaType = x , MediaCoverPhoto = inf.SystemLogo };
            return View(Media);
        }
        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var Media = db.SystemMedias.Find(Id);
            return View("Add", Media);
        }


        [ValidateInput(false)]
        [HttpPost]
        public ActionResult Add(SystemMedia Media,List<int> Files, HttpPostedFileBase MediaCoverPhoto)
        {
            var db = new Entities();
            var files = db.Galleries.Where(x => x.MediaID == Media.Id).ToList();
            var inf = db.SystemInformations.FirstOrDefault();
            if (MediaCoverPhoto != null)
            {
                var fotoformat = Path.GetExtension(MediaCoverPhoto.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/Media/Cover/" + fotoad));
                MediaCoverPhoto.SaveAs(fotoyol);
                Media.MediaCoverPhoto = "/Upload/Media/Cover/" + fotoad;
            }
            else if(Media.MediaCoverPhoto == null)
            {
                Media.MediaCoverPhoto = inf.SystemLogo;
            }
            db.Entry(Media).State = Media.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            foreach (var x in files)
            {
                db.Galleries.Remove(x);
                db.SaveChanges();
            }
            if (Files != null && Files.Count() != 0)
            {
                foreach (var file in Files)
                {
                    var gallery = new Gallery();
                    gallery.UrlID = file;
                    gallery.MediaID = Media.Id;
                    gallery.Deleted = false;
                    db.Entry(gallery).State = gallery.Id > 0 ? EntityState.Modified : EntityState.Added;
                    db.SaveChanges();
                }
            }

            return RedirectToAction("List", new { TurID = Media.MediaTypeID });
        }

        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var media = db.SystemMedias.Find(Id);
            media.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }

        public ActionResult FileUpload(HttpPostedFileBase file)
        {
            var db = new Entities();
            var data = new EDMX.MediaUrl() { };
            if (file != null && file.ContentLength > 0)
            {
                var fotoformat = Path.GetExtension(file.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/Media/Gallery/" + fotoad));
                file.SaveAs(fotoyol);
                data.Url = "/Upload/Media/Gallery/" + fotoad;
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
            var data = db.MediaUrls.Find(Id);
            var path = Server.MapPath(data.Url);
            var gallery = db.Galleries.Where(x=>x.UrlID == data.Id).FirstOrDefault();
            if (gallery != null)
            {
                db.Galleries.Remove(gallery);
            }
            System.IO.File.Delete(path);
            db.MediaUrls.Remove(data);
            db.SaveChanges();
            return Json(new { success = true });
        }

    }
}