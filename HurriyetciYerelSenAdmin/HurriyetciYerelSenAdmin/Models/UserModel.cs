using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HurriyetciYerelSenAdmin.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string UserEmail { get; set; }
        public string UserPhoneNumber { get; set; }
        public string UserPassword { get; set; }
        public HttpPostedFileBase UserProfilePic { get; set; }
        public string UserPhoto { get; set; }
        public IEnumerable<SelectListItem> UserPermissionSelectlist { get; set; }
        public int? UserClassID { get; set; }
    }
}