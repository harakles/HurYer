using HurriyetciYerelSen.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Web;
using WebGrease;

namespace HurriyetciYerelSen.Managers
{
    public class GeneralManager
    {
        public static SystemInformation GetInf()
        {
            var db = new Entities();
            var data = db.SystemInformations.Find(1);
            return data;
        }

        public static string GetUserIp()
        {
            var ip = string.Empty;
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
                ip = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            else if (HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"] != null && HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"].Length != 0)
                ip = HttpContext.Current.Request.ServerVariables["HTTP_CLIENT_IP"];
            else if (!string.IsNullOrEmpty(HttpContext.Current.Request.UserHostAddress))
                ip = HttpContext.Current.Request.UserHostName;
            return ip;
        }
        public static VisitLog Load()
        {
            var bugun = DateTime.Today;
            using (var db = new Entities())
            {
                var data = new VisitLog();
                var ıp = GeneralManager.GetUserIp();
                var sorgu = db.VisitLogs.Where(x => x.Ip == ıp && x.Date == bugun);
                if (sorgu.Any())
                {

                }
                else
                {

                    data.Ip = GeneralManager.GetUserIp();
                    data.Date = DateTime.Today;
                    db.VisitLogs.Add(data);
                    db.SaveChanges();
                }
                return null;
            }
        }
    }
}