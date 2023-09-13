using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Controllers
{
    public class LoginController : Controller
    {
        [HttpGet]
        public ActionResult Index(string e)
        {
            var db = new Entities();
            var user = Session[UserSession.SessionKeyName] as User;
            if (user != null)
            {
                return RedirectToAction("SessionCheck", "Redirect");
            }
            if (HttpContext.Request.Cookies["RememberMeCookie"].Value != null && HttpContext.Request.Cookies["RememberMeCookie"].Value != "")
            {
                var cookiecode = HttpContext.Request.Cookies["RememberMeCookie"].Value;
                var query = db.Users.Where(x => x.RememberCookie == cookiecode).FirstOrDefault();
                if (query != null)
                {
                    Session.Add(UserSession.SessionKeyName, query);
                    return RedirectToAction("SessionCheck", "Redirect");
                }
                else
                {
                    Response.Cookies.Remove("RememberMeCookie");
                    Session.Remove(UserSession.SessionKeyName);
                }
            }
            ViewBag.System = db.SystemInformations.FirstOrDefault();
            ViewBag.Error = e;
            return View();
        }

        [HttpPost]
        public ActionResult Index(LoginModel data)
        {
            if (data.Password == null || data.Email == null)
            {
                var e1 = "E-posta Yada Şifre Boş Geçilemez";
                return Redirect("/Login/Index?e=" + e1);
            }
            var db = new Entities();
            var IsLogged = LoginManager.LogIn(data);
            if (IsLogged != null)
            {
                Session.Add(UserSession.SessionKeyName, IsLogged);
                if (data.RememberMe)
                {
                    var random = new Random();
                    var cookiecode = random.Next(11111111, 99999999);
                    HttpCookie cookie = new HttpCookie("RememberMeCookie");
                    cookie.Secure = true;
                    cookie.Expires = DateTime.Now.AddDays(30);
                    cookie.Value = cookiecode.ToString();
                    Response.Cookies.Add(cookie);
                    var user = db.Users.Find(IsLogged.Id);
                    user.RememberCookie = cookiecode.ToString();
                    db.SaveChanges();
                }
                return RedirectToAction("SessionCheck", "Redirect");
            }
            var e = "E-Posta Yada Şifre Yanlış";
            return Redirect("/Login/Index?e=" + e);
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            Response.Cookies["RememberMeCookie"].Value = null;
            //throw new Exception(Request.Cookies["RememberMeCookie"].Value);
            return Redirect("/Login/Index");
        }
    }
}