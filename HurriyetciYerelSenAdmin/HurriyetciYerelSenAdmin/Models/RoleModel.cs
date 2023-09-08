using HurriyetciYerelSenAdmin.EDMX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSenAdmin.Models
{
    public class RoleModel
    {
        public int Id { get; set; }
        public string UserClassName { get; set; }
        public List<int> Permissions { get; set; }
        public string selected { get; set; }


    }
}