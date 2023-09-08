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
    public class RoleController : Controller
    {
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = RoleManager.GetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.UserClassName,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add() 
        {
            var db = new Entities();
            var model = new RoleModel();
            ViewBag.Permissions = new SelectList(db.UserPermissions.Where(x => x.Deleted != true).ToList(), "Id", "PermissionName");
            return View(model);
        }
        [HttpGet]
        public ActionResult Update(int Id) 
        {
            var db = new Entities();
            var rol = db.UserClasses.Find(Id);
            var data = new RoleModel()
            {
                Id = Id,
                UserClassName= rol.UserClassName,
                selected = rol.Permissions,
            };
            ViewBag.Permissions = new SelectList(db.UserPermissions.Where(x => x.Deleted != true).ToList(), "Id", "PermissionName", selectedValue: data.Permissions);
            return View("Add", data);
        }
        public ActionResult Delete(int Id) 
        {
            var db = new Entities();
            var data = db.UserClasses.Find(Id);
            data.Deleted = true;
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return Json("Success");
        }
        [HttpPost]
        public ActionResult Add(RoleModel data) 
        {
            var db = new Entities();
            var role = new UserClass()
            {
                Id= data.Id,
                UserClassName = data.UserClassName,
                Permissions = string.Join(",", data.Permissions),
            };
            db.Entry(role).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }
    }
}