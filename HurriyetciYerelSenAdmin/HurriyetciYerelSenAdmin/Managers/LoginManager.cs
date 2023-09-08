using HurriyetciYerelSenAdmin.EDMX;
using HurriyetciYerelSenAdmin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HurriyetciYerelSenAdmin.Managers
{
    public class LoginManager
    {
        public static User LogIn(LoginModel loginModel)
        {
            var db = new Entities();
            var encpas = Cryption.Encrypt(loginModel.Password);
            var user = db.Users.Where(x=>x.UserEmail == loginModel.Email && x.UserPassword == encpas && x.Deleted != true).FirstOrDefault();
            if (user != null)
            {
                return user;
            }
            return null;
        }
    }
}