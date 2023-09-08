using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class MemberController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = MemberManager.GetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.MemberPhoto,
                asset.MemberName,
                asset.MemberSurname,
                asset.MemberPosition,
                asset.MemberPhoneNumber,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var model = new Member();
            model.CentralCheckers = false;
            model.CentralDirectors = false;
            model.CentralDiscipline = false;
            model.Funders = false;
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var model = db.Members.Find(Id);
            return View("Add", model);
        }

        [HttpPost]
        public ActionResult Add(Member data , HttpPostedFileBase MemberPhoto)
        {
            var db = new Entities();
            if (MemberPhoto != null)
            {
                var fotoformat = Path.GetExtension(MemberPhoto.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/Member/Photo/" + fotoad));
                MemberPhoto.SaveAs(fotoyol);
                data.MemberPhoto = "/Upload/Member/Photo/" + fotoad;
               
            }
            else
            {
                if (data.MemberPhoto == null)
                {
                    data.MemberPhoto = "/assets/img/avatars/base.png";
                }
            }
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var data = db.Members.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }
    }
}