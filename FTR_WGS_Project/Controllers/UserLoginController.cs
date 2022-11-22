using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FTR_WGS_Project.Models;
using FTR_WGS_Project.ViewModels;

namespace FTR_WGS_Project.Controllers
{
    public class UserLoginController : Controller
    {
        TravelContext db;

        public UserLoginController()
        {
            db = new TravelContext();
        }

        // GET: UserLogin
        public ActionResult Login()
        {
            return View(new UserLoginViewModel());
        }

        public ActionResult CheckingUser(UserLoginViewModel user)
        {
            if (ModelState.IsValid)
            {

                UserLogin userData = (from u in db.UserLogins where u.UserName == user.UserLogin.UserName && u.Password == user.UserLogin.Password select u).SingleOrDefault();

                if (userData != null)
                {
                    Session["empid"] = userData.EmpId.ToString();
                    return RedirectToAction("TravelDetails", "BasicInformation");
                }
                else
                {
                    ModelState.AddModelError("Error", "INVALID USER , PLEASE LOGIN AGAIN !!");
                }
            }
            return View("Login", user);
        }

        public ActionResult Logout()
        {
            Session.Remove("empid");
            return RedirectToAction("Login", "UserLogin");
        }
    }
}