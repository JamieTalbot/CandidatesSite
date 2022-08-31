using CandidatesSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CandidatesSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(CandidatesSite.Models.Admin adminModel)
        {
            using (AdminDataEntities db = new AdminDataEntities())
            {
                var adminDetails = db.Admins.Where(x => x.UserName == adminModel.UserName && x.Password == adminModel.Password).FirstOrDefault();
                if (adminDetails == null)
                {
                    adminModel.LoginErrorMessage = "Inncorrect username or password";
                    return View("Index", adminModel);
                }
                else
                {
                    Session["userID"] = adminDetails.UserID;
                    return RedirectToAction("Admin", "Candidates");
                }
            }
        }

        public ActionResult LogOut()
        {
            Session.Abandon();
            return RedirectToAction("Index", "Admin");
        }
    }
}