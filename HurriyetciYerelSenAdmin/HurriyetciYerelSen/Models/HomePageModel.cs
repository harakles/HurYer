using HurriyetciYerelSen.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSen.Models
{
    public class HomePageModel
    {
        public List<SystemMedia> News { get; set; }
        public List<SystemMedia> Announcment { get; set; }
        public SystemInformation info { get; set; }
    }
}