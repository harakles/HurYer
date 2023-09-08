using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSenAdmin.Models
{
    public class LoginModel
    {
        public string Password { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; } = string.Empty;
        public int SmsCode { get; set; }
        public bool RememberMe { get; set; }
    }
}