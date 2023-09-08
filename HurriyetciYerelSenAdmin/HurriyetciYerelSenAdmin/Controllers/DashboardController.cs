using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class DashboardController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            var db = new Entities();
            var data = new DashboardModal();
            data.TotalVisitCount = db.VisitLogs.ToList().Count();
            data.TotalNewsCount = db.SystemMedias.Where(x=>x.Deleted != true && x.MediaTypeID == 1).ToList().Count();
            data.TotalAnounceCount = db.SystemMedias.Where(x => x.Deleted != true && x.MediaTypeID == 2).ToList().Count();
            data.TotalActionCount = db.Broadcasts.Where(x=>x.Deleted != true && x.BroadcastClassID == 2).ToList().Count();
            data.TotalCourtCount = db.Broadcasts.Where(x=>x.Deleted != true && x.BroadcastClassID == 1).ToList().Count();
            data.TotalAppealCount = db.Applications.Where(x => x.Deleted != true && x.ApplicationCaseID != 3).ToList().Count();
            var oran1 = db.Applications.Where(x=>x.Deleted != true && x.ApplicationCaseID == 1).ToList().Count();
            var oran2 = db.Applications.Where(x=>x.Deleted != true && x.ApplicationCaseID == 2).ToList().Count();
            var oran3 = db.Applications.Where(x=>x.Deleted != true && x.ApplicationCaseID == 3).ToList().Count();
            data.Chart = new[] {oran1,oran2, oran3 };
            var session = Session[UserSession.SessionKeyName] as User;
            if (session != null)
            {
                data.User = new User() { UserName = session.UserName, UserSurname = session.UserSurname };
            }
            else
            {
                data.User = new User() {UserName = "Yükleniyor" , UserSurname = "" };
            }
            return View(data);
        }

        public ActionResult TopMenuPartial(List<UserPermission> navbar)
        {
            return PartialView(navbar);
        }
    }
}