using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CandidatesSite.Models;

namespace CandidatesSite.Controllers
{
    public class LoginController : Controller
    {
        private LoginsDataEntities db = new LoginsDataEntities();

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        // GET: Login/Create
        public ActionResult Create()
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

        // POST: Login/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "userID,UserName,Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                db.Logins.Add(login);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(login);
        }
    }
}