using HurriyetciYerelSenAdmin.EDMX;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSenAdmin.Models
{
    public class DashboardModal
    {
        public int TotalNewsCount { get; set; }
        public int TotalAnounceCount { get; set; }
        public int TotalPetitionCount { get; set; }
        public int TotalCourtCount { get; set; }
        public int TotalActionCount { get; set; }
        public int TotalAppealCount { get; set; }
        public int TotalVisitCount { get; set; }
        public User User { get; set; }
        public int[] Chart { get; set; }
    }
}