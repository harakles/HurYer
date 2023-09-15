using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class BranchController : Controller
    {
        // GET: Branch
        public ActionResult List()
        {
            return View();
        }


        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = BranchManager.GetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.BranchName,
                asset.BranchPhone,
                asset.BranchEMail,
                asset.BranchNumber
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetSubBranchList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int BranchID)
        {
            var db = new Entities();
            var query = BranchManager.GetSubBrachList(requestModel,BranchID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.SubBranchName,
                asset.Email,
                asset.PhoneNumber
                
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetBranchMemberList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel,int BranchID)
        {
            var db = new Entities();
            var query = BranchManager.GetBranchMemberList(requestModel,BranchID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Name,
                asset.EMailAdress,
                asset.Position,
                asset.PhoneNumber
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult Add()
        {
            var data = new Branch();
            return View(data);
        }

        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.Branchs.Find(Id);
            return View("Add", data);
        }

        [HttpPost]
        public ActionResult Add(Branch data)
        {
            var db = new Entities();
            var number = data.BranchPhone[0];
            switch (number)
            {
                case '0':
                    data.BranchPhone = "+9" + data.BranchPhone;
                    break;
                case '5':
                    data.BranchPhone = "+90" + data.BranchPhone;
                    break;
            }
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }

        public ActionResult Delete(int Id) 
        {
            var db = new Entities();
            var data = db.Branchs.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }
        public ActionResult SubBranchAdd(int Id)
        {
            var data = new SubBranch();
            data.BranchID = Id;
            return View(data);
        }

        public ActionResult SubBranchUpdate(int Id) 
        {
            var db = new Entities();
            var data = db.SubBranches.Find(Id);
            return View("SubBranchAdd", data);
        }
        [HttpPost]
        public ActionResult SubBranchAdd(SubBranch data)
        {
            var db = new Entities();
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
            return Redirect($"/Branch/Update?Id={data.BranchID}");
        }
        public ActionResult SubBranchDelete(int Id) 
        {
            var db = new Entities();
            var data = db.SubBranches.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }

        public ActionResult BranchMemberAdd(int Id)
        {
            var data = new BranchMember();
            data.BranchID = Id;
            return View(data);
        }

        public ActionResult BranchMemberUpdate(int Id)
        {
            var db = new Entities();
            var data = db.BranchMembers.Find(Id);
            return View("BranchMemberAdd", data);
        }

        [HttpPost]
        public ActionResult BranchMemberAdd(BranchMember data) 
        {
            var db = new Entities();
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
            return Redirect($"/Branch/Update?Id={data.BranchID}");
        }

        public ActionResult BranchMemberDelete(int Id) 
        {
            var db = new Entities();
            var data = db.BranchMembers.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }
    }
}