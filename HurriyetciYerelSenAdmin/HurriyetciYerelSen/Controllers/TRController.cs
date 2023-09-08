﻿using HurriyetciYerelSen.EDMX;
using HurriyetciYerelSen.Models;
using Microsoft.Ajax.Utilities;
using PagedList;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSen.Controllers
{
    public class Sabit
    {
        public static readonly string Admin = "http://localhost:9091";
    }
    public class TRController : Controller
    {
        // GET: TR
        public ActionResult AnaSayfa() 
        {
            var db = new Entities();
            var data = new HomePageModel();
            data.News = db.SystemMedias.OrderByDescending(x=>x.MediaDate).Where(x=>x.Deleted != true && x.MediaTypeID == 1).Take(5).ToList();
            data.Announcment = db.SystemMedias.OrderByDescending(x=>x.MediaDate).Where(x=>x.Deleted != true && x.MediaTypeID == 2).Take(6).ToList();
            data.info = db.SystemInformations.Find(1);
            return View(data); 
        }
        public ActionResult Haberler(int page = 1)
        {
            var db = new Entities();
            var news = db.SystemMedias.Where(x => x.MediaTypeID == 1 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(news);
        }
        public ActionResult HaberDetay(int Id)
        {
            var db = new Entities();
            var detail = db.SystemMedias.Find(Id);
            return View(detail);
        }
        public ActionResult Duyurular(int page = 1)
        {
            var db = new Entities();
            var ann = db.SystemMedias.Where(x => x.MediaTypeID == 2 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(ann);
        }

        public ActionResult SonMedyalar(int Id)
        {
            var db = new Entities();
            var data = db.SystemMedias.OrderByDescending(x => x.MediaDate).Where(x => x.Deleted != true && x.MediaTypeID == Id).Take(3).ToList();
            return PartialView(data);
        }
        public ActionResult DuyuruDetay(int Id)
        {
            var db = new Entities();
            var detail = db.SystemMedias.Find(Id);
            return View(detail);
        }

        public ActionResult EylemKararları(int page = 1)
        {
            var db = new Entities();
            var EK = db.Broadcasts.Where(x => x.BroadcastClassID == 2 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(EK);
        }

        public ActionResult EylemKararı(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult Davalar(int page = 1)
        {
            var db = new Entities();
            var Davalar = db.Broadcasts.Where(x => x.BroadcastClassID == 1 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(Davalar);
        }

        public ActionResult Dava(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult Dilekceler(int page = 1)
        {
            var db = new Entities();
            var Dk = db.Broadcasts.Where(x => x.BroadcastClassID == 1002 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(Dk);
        }

        public ActionResult Dilekce(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult Yonetmelikler(int page = 1)
        {
            var db = new Entities();
            var YL = db.Broadcasts.Where(x => x.BroadcastClassID == 1003 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(YL);
        }

        public ActionResult Yonetmelik(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult MahkemeKararlari(int page = 1)
        {
            var db = new Entities();
            var MK = db.Broadcasts.Where(x => x.BroadcastClassID == 1004 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(MK);
        }

        public ActionResult MahkemeKarari(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult HukukiDegerlendirmeler(int page = 1)
        {
            var db = new Entities();
            var HD = db.Broadcasts.Where(x => x.BroadcastClassID == 1005 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(HD);
        }

        public ActionResult HukukiDegerlendirme(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult Tuzuk(int page = 1)
        {
            var db = new Entities();
            var Tz = db.Broadcasts.Where(x => x.BroadcastClassID == 1006 && x.Deleted != true).ToList().ToPagedList(page, 6);
            return View(Tz);
        }

        public ActionResult TuzukDetay(int Id)
        {
            var db = new Entities();
            var detail = db.Broadcasts.Find(Id);
            return View(detail);
        }

        public ActionResult Hakkimizda()
        {
            var db = new Entities();
            var detail = db.AboutUs.Find(1);
            return View(detail);
        }

        public ActionResult MerakEdilenler(int page = 1)
        {
            var db = new Entities();
            var detail = db.Questions.Where(x => x.Deleted != true).ToList().ToPagedList(page, 24);
            return View(detail);
        }

        public ActionResult Ilkelerimiz(int page = 1)
        {
            var db = new Entities();
            var detail = db.Principles.Where(x => x.Deleted != true).ToList().ToPagedList(page, 36);
            return View(detail);
        }

        public ActionResult GetSubeler(string Search)
        {
            var db = new Entities();
            var data = new List<Branch>();
            if (!string.IsNullOrEmpty(Search))
            {
                data = db.Branchs.OrderBy(x => x.BranchNumber).Where(x => x.Deleted != true && x.BranchName.Contains(Search.ToLower())).ToList();
            }
            else
            {
                data = db.Branchs.OrderBy(x => x.BranchNumber).Where(x => x.Deleted != true).ToList();
            }
            return Json(data);
        }

        public ActionResult Subeler()
        {
            return View();
        }

        public ActionResult SubeDetay(int Id)
        {
            var db = new Entities();
            var data = db.Branchs.Find(Id);
            return View(data);
        }

        public ActionResult Konfederasyon()
        {
            var db = new Entities();
            var data = db.Unions.Where(x => x.Deleted != true).ToList();
            return View(data);
        }

        public ActionResult Kurucular()
        {
            var db = new Entities();
            var data = db.Members.Where(x => x.Deleted != true && x.Funders == true).ToList();
            return View(data);
        }

        public ActionResult Uyelik()
        {
            var db = new Entities();
            var data = db.Broadcasts.Where(x => x.Deleted != true && x.BroadcastClassID == 2002).ToList();
            return View(data);
        }

        public ActionResult OnlineBasvuru()
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
            return PartialView(data);
        }

        [HttpPost]
        public ActionResult Uyelik(Application data)
        {
            var db = new Entities();
            if(data != null)
            {
                db.Entry(data).State = data.Id > 0 ? EntityState.Unchanged : EntityState.Added;
                db.SaveChanges();
            }
            
            return RedirectToAction("OnlineUyelik");
        }

        public ActionResult OnlineUyelik()
        {
            return View();
        }

    }
}