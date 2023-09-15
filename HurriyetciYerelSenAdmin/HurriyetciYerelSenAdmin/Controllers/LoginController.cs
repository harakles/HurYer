using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Managers;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
            if(user != null)
            {
                return RedirectToAction("SessionCheck", "Redirect");
            }
            else
            {
                if (HttpContext.Request.Cookies["RememberMeCookie"] != null)
                {


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
                            Session.RemoveAll();
                            Session.Abandon();
                            Response.Cookies.Remove("RememberMeCookie");
                            Response.Cookies.Remove("ASP.NET_SessionId");
                            foreach (var x in Response.Cookies.AllKeys)
                            {
                                Response.Cookies.Remove(x);
                            }
                            Response.Cookies.Clear();
                            ViewBag.System = db.SystemInformations.FirstOrDefault();
                            ViewBag.Error = "Oturum Hatırlanamadı";
                            return View();
                        }
                    }
                    else
                    {
                        Session.RemoveAll();
                        Session.Abandon();
                        Response.Cookies.Remove("RememberMeCookie");
                        Response.Cookies.Remove("ASP.NET_SessionId");
                        foreach (var x in Response.Cookies.AllKeys)
                        {
                            Response.Cookies.Remove(x);
                        }
                        Response.Cookies.Clear();
                        ViewBag.System = db.SystemInformations.FirstOrDefault();
                        ViewBag.Error = e;
                        return View();
                    }
                }
                else
                {
                    ViewBag.System = db.SystemInformations.FirstOrDefault();
                    ViewBag.Error = e;
                    return View();
                }
            }
            
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
                    HttpCookie rememberMeCookie = new HttpCookie("RememberMeCookie");
                    rememberMeCookie.Value = cookiecode.ToString();
                    rememberMeCookie.Expires = DateTime.Now.AddDays(30); 
                    Response.Cookies.Add(rememberMeCookie);
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
            return Redirect("/Login/Index");
        }
    }
}