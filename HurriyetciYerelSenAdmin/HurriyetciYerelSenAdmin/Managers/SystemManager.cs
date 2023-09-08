using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Drawing;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class Sabit
    {
        public static readonly string Admin = "";
    }
    public class SystemManager
    {

        public static List<UserPermission> GetNav(int Id)
        {
            var db = new Entities();
            var user = db.Users.Find(Id);
            string[] permissions = user.UserClass.Permissions.Split(',');
            int[] permissonIDs = new int[permissions.Length];
            for (int i = 0; i < permissions.Length; i++)
            {
                int permissonID;
                if (int.TryParse(permissions[i], out permissonID))
                {
                    permissonIDs[i] = permissonID;
                }
            }

            var permissionList = new List<UserPermission>();

            foreach (int permissionID in permissonIDs)
            {
                var permdata = db.UserPermissions.Where(x => x.Id == permissionID).FirstOrDefault();
                    permissionList.Add(permdata);
                
            }
            var reqpath = HttpContext.Current.Request;

            var listofperms = permissionList.Select(x => x.UserPages);
            if (reqpath.Url.AbsolutePath == "/Login/Index")
            {
                return permissionList;
            }
            if (reqpath.Url.Segments[2].Contains("Delete") )
            {
                if (reqpath.Url.Query != null)
                {
                    if (!(from pages in listofperms
                          let perms = pages.Select(x => new { x.Id, Url = "/" + x.CotrollerName + "/" + x.ActionName + x.UrlParameter }).ToList()
                          from item in perms
                          let deg = reqpath.RawUrl
                          let url = item.Url
                          where deg == url
                          select deg).Any()) return null;
                }
            }
            if (!(from pages in listofperms
                  let perms = pages.Select(x => new { x.Id, Url = "/" + x.CotrollerName + "/" + x.ActionName }).ToList()
                  from item in perms
                  let deg = reqpath.Url.AbsolutePath
                  let url = item.Url
                  where deg == url
                  select deg).Any()) return null;

            return permissionList;
        }

        public static SystemInformation GetSystem()
        {
            var db = new Entities();
            var system = db.SystemInformations.FirstOrDefault();
            return system;
        }
    }
}