using ShoppingList.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ShoppingList.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(UserVM user)
        {
            if (user.Username == "mnikolaidis" && user.Password == "12345")
            {
                FormsAuthentication.SetAuthCookie(user.Username, user.RememberMe);
            }
            return RedirectToAction("Index", "Home");
        }

        //[HttpPost]
        //public ActionResult Login()
        // {
        //if(user.Username == "mnikolaidis" && user.Password == "12345")
        //{
        //    FormsAuthentication
        //        .SetAuthCookie(user.Username, user.RememberMe);
        //}
        //return RedirectToAction("List", "Home");

        //  return View();
        //}


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("List", "Home");
        }
    }
}