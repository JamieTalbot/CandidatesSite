using CandidatesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidatesSite.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(CandidatesSite.Models.Login loginModel)
        {
            using (LoginsDataEntities db = new LoginsDataEntities())
            {
                var loginDetails = db.Logins.Where( x => x.UserName==loginModel.UserName && x.Password == loginModel.Password).FirstOrDefault();
                if(loginDetails == null)
                {
                    loginModel.LoginErrorMessage = "Inncorrect username or password";
                    return View("Index", loginModel);
                }
                else{
                    Session["userID"] = loginDetails.UserID;
                    return RedirectToAction("Index", "Home");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Login");
        }
    }
}