using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using HurriyetciYerelSenAdmin.Models;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class UserController : Controller
    {

        public ActionResult Settings()
        {
            var db = new Entities();
            var session = Session[UserSession.SessionKeyName] as User;
            if (session == null)
            {
                return RedirectToAction("Index","Login");
            }
            else
            {
                var data = db.Users.Find(session.Id);
                return View(data);
            }
        }

        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = UserManager.GetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.UserName,
                asset.UserSurname,
                asset.UserPhoneNumber,
                asset.UserEmail,
                asset.UserProfilePic,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var db = new Entities();
            var model = new UserModel();
            model.UserPhoto = "/assets/img/avatars/base.png";
            ViewBag.Permissions = new SelectList(db.UserClasses.Where(x => x.Deleted != true).ToList(), "Id", "UserClassName");
            return View(model);
        }

        [HttpGet]
        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.Users.Find(Id);
            ViewBag.Permissions = new SelectList(db.UserClasses.Where(x => x.Deleted != true).ToList(), "Id", "UserClassName", selectedValue: data.UserClassID);
            var user = new UserModel()
            {
                Id = data.Id,
                UserName = data.UserName,
                UserSurname = data.UserSurname,
                UserPhoto = data.UserProfilePic,
                UserClassID = data.UserClassID,
                UserEmail = data.UserEmail,
                UserPassword = Cryption.Decrypt(data.UserPassword),
                UserPhoneNumber = data.UserPhoneNumber,
            };
            return View("Add", user);
        }

        [HttpPost]
        public ActionResult Add(UserModel data)
        {
            var db = new Entities();
            var user = new User()
            {
                Id = data.Id,
                UserName = data.UserName,
                UserClassID = data.UserClassID == 0 ? null : data.UserClassID,
                UserEmail = data.UserEmail,
                UserPassword = Cryption.Encrypt(data.UserPassword),
                UserSurname = data.UserSurname,
                UserProfilePic = data.UserPhoto
            };
            var number = data.UserPhoneNumber[0];
            switch (number)
            {
                case '0':
                    user.UserPhoneNumber = "+9" + data.UserPhoneNumber;
                    break;
                case '5':
                    user.UserPhoneNumber = "+90" + data.UserPhoneNumber;
                    break;
            }
            if (data.UserProfilePic != null)
            {
                var fotoformat = Path.GetExtension(data.UserProfilePic.FileName);
                var fotoad = Guid.NewGuid() + fotoformat;
                var fotoyol = Path.Combine(Server.MapPath("/Upload/User/Photo/" + fotoad));
                data.UserProfilePic.SaveAs(fotoyol);
                user.UserProfilePic = "/Upload/User/Photo/" + fotoad;
            }
            var currentuser = Session[UserSession.SessionKeyName] as User;
            
            db.Entry(user).State = user.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            db = new Entities();
            if (currentuser.Id == user.Id)
            {
                var query = db.Users.Where(x=>x.Id == user.Id && x.Deleted != true).FirstOrDefault();
                var data1 = query.UserClass; 
                Session[UserSession.SessionKeyName] = query;
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var data = db.Users.Find(Id);
            data.Deleted = true;
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return Json("Success");
        }


    }
}