using HurriyetciYerelSen.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
    }
}