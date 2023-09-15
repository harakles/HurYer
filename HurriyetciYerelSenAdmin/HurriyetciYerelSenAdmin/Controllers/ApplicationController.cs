using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DataTables.Mvc;
using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using Microsoft.Ajax.Utilities;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class ApplicationController : Controller
    {
        // GET: Application
        #region Lists
        public ActionResult List()
        {
            var db = new Entities();
            ViewBag.Filter = new SelectList(db.ApplicationCases.Where(x => x.Deleted != true).ToList(), "Id", "Situation");
            return View();
        }
        public ActionResult GenderList()
        {
            return View();
        }
        public ActionResult EducationList()
        {
            return View();
        }
        public ActionResult OrganisationList()
        {
            return View();
        }
        public ActionResult ProvinceList()
        {
            return View();
        }
        public ActionResult StaffList()
        {
            return View();
        }
        public ActionResult BloodTypeList()
        {
            return View();
        }
        public ActionResult CaseList()
        {
            return View();
        }
        #endregion

        #region Add/Update/Delete
        public ActionResult Add()
        {
            var db = new Entities();
            var data = new Application();
            ViewBag.GenderSelect = new SelectList(db.ApplicationGenders.Where(x => x.Deleted != true).ToList(), "Id", "Gender");
            ViewBag.EducationSelect = new SelectList(db.ApplicationEducations.Where(x => x.Deleted != true).ToList(), "Id", "EducationName");
            ViewBag.OrganisationSelect = new SelectList(db.ApplicationOrganisations.Where(x => x.Deleted != true).ToList(), "Id", "OrganisationName");
            ViewBag.ProvinceSelect = new SelectList(db.ApplicationProvinces.Where(x => x.Deleted != true).ToList(), "Id", "Province");
            ViewBag.StaffSelect = new SelectList(db.ApplicationStaffs.Where(x => x.Deleted != true).ToList(), "Id", "Staff");
            ViewBag.CaseSelect = new SelectList(db.ApplicationCases.Where(x => x.Deleted != true).ToList(), "Id", "Situation");
            ViewBag.BloodType = new SelectList(db.ApplicationBloodTypes.Where(x => x.Deleted != true).ToList(), "Id", "BloodType");
            return View(data);
        }

        public ActionResult GetDistrictSelectList(int Id)
        {
            var db = new Entities();
            var data = new SelectList(db.ApplicationDistricts.Where(x => x.ProvinceId == Id && x.Deleted != true).ToList(), "Id", "District");
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update(int Id)
        {
            var db = new Entities();
            var data = db.Applications.Find(Id);
            ViewBag.GenderSelect = new SelectList(db.ApplicationGenders.Where(x => x.Deleted != true).ToList(), "Id", "Gender");
            ViewBag.EducationSelect = new SelectList(db.ApplicationEducations.Where(x => x.Deleted != true).ToList(), "Id", "EducationName");
            ViewBag.OrganisationSelect = new SelectList(db.ApplicationOrganisations.Where(x => x.Deleted != true).ToList(), "Id", "OrganisationName");
            ViewBag.ProvinceSelect = new SelectList(db.ApplicationProvinces.Where(x => x.Deleted != true).ToList(), "Id", "Province");
            ViewBag.StaffSelect = new SelectList(db.ApplicationStaffs.Where(x => x.Deleted != true).ToList(), "Id", "Staff");
            ViewBag.CaseSelect = new SelectList(db.ApplicationCases.Where(x => x.Deleted != true).ToList(), "Id", "Situation");
            ViewBag.BloodType = new SelectList(db.ApplicationBloodTypes.Where(x => x.Deleted != true).ToList(), "Id", "BloodType");
            return View("Add",data);
        }
        [HttpPost]
        public ActionResult Add(Application data)
        {
            var db = new Entities();
            var number = data.ApplicationPhoneNumber[0];
            switch (number)
            {
                case '0':
                    data.ApplicationPhoneNumber = "+9" + data.ApplicationPhoneNumber;
                    break;
                case '5':
                    data.ApplicationPhoneNumber = "+90" + data.ApplicationPhoneNumber;
                    break;
            }
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("List");
        }
        public ActionResult Delete(int Id)
        {
            var db = new Entities();
            var data = db.Applications.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return Json("Success");
        }

        #region Gender
        public ActionResult GenderAdd()
        {
            var data = new ApplicationGender();
            return View(data);
        }
        public ActionResult GenderUpdate(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationGenders.Find(Id);
            return View("GenderAdd", data);
        }
        [HttpPost]
        public ActionResult GenderAdd(ApplicationGender data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("GenderList");
        }
        public ActionResult GenderDelete(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationGenders.Find(Id);
            data.Deleted = true; db.SaveChanges();
            return RedirectToAction("GenderList", "Application");
        }
        #endregion

        #region Education
        public ActionResult EducationAdd()
        {
            var data = new ApplicationEducation();
            return View(data);
        }
        public ActionResult EducationUpdate(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationEducations.Find(Id);
            return View("EducationAdd", data);
        }
        [HttpPost]
        public ActionResult EducationAdd(ApplicationEducation data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("EducationList");
        }
        public ActionResult EducationDelete(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationEducations.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("EducationList", "Application");
        }
        #endregion

        #region Organisation
        public ActionResult OrganisationAdd()
        {
            var data = new ApplicationOrganisation();
            return View(data);
        }
        public ActionResult OrganisationUpdate(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationOrganisations.Find(Id);
            return View("OrganisationAdd", data);
        }
        [HttpPost]
        public ActionResult OrganisationAdd(ApplicationOrganisation data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("OrganisationList");
        }
        public ActionResult OrganisationDelete(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationOrganisations.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("OrganisationList", "Application");
        }
        #endregion

        #region Province
        public ActionResult ProvinceAdd()
        {
            var data = new ApplicationProvince();
            return View(data);
        }
        public ActionResult ProvinceUpdate(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationProvinces.Find(Id);
            return View("ProvinceAdd", data);
        }
        [HttpPost]
        public ActionResult ProvinceAdd(ApplicationProvince data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("ProvinceList");
        }
        public ActionResult ProvinceDelete(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationProvinces.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("ProvinceList", "Application");
        }
        #endregion

        #region District
        public ActionResult DistrictAdd(int Id)
        {
            var data = new ApplicationDistrict();
            data.ProvinceId = Id;
            data.Id = 0;
            return View(data);
        }
        public ActionResult DistrictUpdate(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationDistricts.Find(Id);
            return View("DistrictAdd", data);
        }
        [HttpPost]
        public ActionResult DistrictAdd(ApplicationDistrict data)
        {
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return Redirect("/Application/ProvinceUpdate?Id=" + data.ProvinceId);
        }
        public ActionResult DistrictDelete(int Id)
        {
            var db = new Entities();
            var data = db.ApplicationDistricts.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("DistrictList", "Application");
        }
        #endregion

        #region Staff
        public ActionResult StaffAdd() 
        { 
            var data = new ApplicationStaff(); 
            return View(data); 
        }
        public ActionResult StaffUpdate(int Id)
        { 
            var db = new Entities();
            var data = db.ApplicationStaffs.Find(Id); 
            return View("StaffAdd", data);
        }
        [HttpPost]
        public ActionResult StaffAdd(ApplicationStaff data) 
        { 
            var db = new Entities(); 
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges();
            return RedirectToAction("StaffList"); 
        }
        public ActionResult StaffDelete(int Id) 
        { 
            var db = new Entities(); 
            var data = db.ApplicationStaffs.Find(Id); 
            data.Deleted = true;
            db.SaveChanges(); 
            return RedirectToAction("StaffList", "Application");
        }
        #endregion

        #region BloodType
        public ActionResult BloodTypeAdd() 
        { 
            var data = new ApplicationBloodType();
            return View(data); 
        }
        public ActionResult BloodTypeUpdate(int Id) 
        { 
            var db = new Entities();
            var data = db.ApplicationBloodTypes.Find(Id); 
            return View("BloodTypeAdd", data);
        }
        [HttpPost]
        public ActionResult BloodTypeAdd(ApplicationBloodType data) 
        { 
            var db = new Entities(); 
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added; 
            db.SaveChanges(); 
            return RedirectToAction("BloodTypeList");
        }
        public ActionResult BloodTypeDelete(int Id)
        { 
            var db = new Entities();
            var data = db.ApplicationBloodTypes.Find(Id);
            data.Deleted = true;
            db.SaveChanges();
            return RedirectToAction("BloodTypeList", "Application"); 
        }
        #endregion

        #region Case
        public ActionResult CaseAdd() 
        { 
            var data = new ApplicationCase();
            return View(data);
        }
        public ActionResult CaseUpdate(int Id)
        { 
            var db = new Entities();
            var data = db.ApplicationCases.Find(Id);
            return View("CaseAdd", data);
        }
        [HttpPost]
        public ActionResult CaseAdd(ApplicationCase data) 
        { 
            var db = new Entities();
            db.Entry(data).State = data.Id > 0 ? EntityState.Modified : EntityState.Added;
            db.SaveChanges(); 
            return RedirectToAction("CaseList");
        }
        public ActionResult CaseDelete(int Id) 
        { 
            var db = new Entities(); 
            var data = db.ApplicationCases.Find(Id); 
            data.Deleted = true; 
            db.SaveChanges();
            return RedirectToAction("CaseList", "Application");
        }
        #endregion

        #endregion

        #region DataTables
        public ActionResult GetList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, string CaseID)
        {
            var db = new Entities();
            var query = ApplicationManager.GetList(requestModel, CaseID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.ApplicationName,
                asset.ApplicationSurname,
                asset.ApplicationPhoneNumber,
                asset.ApplicationEmail,
                Case = asset.ApplicationCase.Situation
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetGenderList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetGenderList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Gender,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetEducationList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetEducationList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.EducationName,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetOrganisationList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetOrganisationList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.OrganisationName,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetProvinceList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetProvinceList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Province,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetDistrictList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel, int ProvinceID)
        {
            var db = new Entities();
            var query = ApplicationManager.GetDistrictList(requestModel, ProvinceID, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.District,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetStaffList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetStafftList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Staff,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetBloodTypeList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetBloodTypetList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.BloodType,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        public ActionResult GetCaseList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {
            var db = new Entities();
            var query = ApplicationManager.GetCaseList(requestModel, out var totalCount, out var filteredCount).ToList();
            var data = query.Select(asset => new
            {
                asset.Id,
                asset.Situation,
            }).ToList();
            return Json(new DataTablesResponse(requestModel.Draw, data, filteredCount, totalCount),
                JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}