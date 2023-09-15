using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class RedirectController : Controller
    {
        // GET: Redirect
        public ActionResult SessionCheck()
        {
            var db = new Entities();
            var current = Session[UserSession.SessionKeyName] as User;
            string[] perms = current.UserClass.Permissions.Split(',');
            var permid = Convert.ToInt32(perms[0]);
            var pageperm = db.UserPermissions.Where(x => x.Id == permid).FirstOrDefault();
            var page = pageperm.Link + pageperm.UrlParameter;
            var ActionName = Regex.Match(page, @"(\w+)$").Value;
            var ControllerName = Regex.Match(page, @"[^\/](\w+)").Value;
            var Id = Regex.Match(page, @"\?\w+=\d+");
            if (Id != null){
                return Redirect("/" + ControllerName + "/" + ActionName+Id);
            }
            return Redirect("/"+ControllerName+"/"+ActionName);
        }

    }
}