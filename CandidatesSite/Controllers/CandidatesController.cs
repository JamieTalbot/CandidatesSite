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
    public class CandidatesController : Controller
    {
        private CandidatesDataEntities db = new CandidatesDataEntities();

        // GET: Candidates
        public ActionResult Index()
        {
            return View(db.Candidates.ToList());
        }

        // GET: Candidates/Admin
        public ActionResult Admin()
        {
            return View(db.Candidates.ToList());
        }

        // SEARCH FUNCTION FOR: Candidates/Admin
        public JsonResult GetSearchingData(string SearchBy, string SearchValue)
        {
            List<Candidate> CandidateList = new List<Candidate>();
            if(SearchBy == "C_NET_ASP")
            {
                try
                {
                    int C_NET_ASP = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.C_NET_ASP == C_NET_ASP || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for C#.NET & ASP", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "CSS")
            {
                try
                {
                    int CSS = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.CSS == CSS || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for CSS", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "HTML")
            {
                try
                {
                    int HTML = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.HTML == HTML || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for HTML", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "Java")
            {
                try
                {
                    int Java = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.Java == Java || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for Java", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "JavaScript")
            {
                try
                {
                    int JavaScript = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.JavaScript == JavaScript || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for JavaScript", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "Python")
            {
                try
                {
                    int Python = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.Python == Python || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for C#.NET & ASP", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "Python_Flask")
            {
                try
                {
                    int Python_Flask = Convert.ToInt32(SearchValue);
                    CandidateList = db.Candidates.Where(x => x.Python_Flask == Python_Flask || SearchValue == null).ToList();
                }
                catch (FormatException)
                {
                    Console.WriteLine("{0} is not valid for Python Flask", SearchValue);
                }
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "Location")
            {
                CandidateList = db.Candidates.Where(x => x.Location.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            if (SearchBy == "Email")
            {
                CandidateList = db.Candidates.Where(x => x.Email.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
            else
            {
                CandidateList = db.Candidates.Where(x => x.Last_Name.Contains(SearchValue) || SearchValue == null).ToList();
                return Json(CandidateList, JsonRequestBehavior.AllowGet);
            }
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,First_Name,Last_Name,Date_of_Birth,Location,Email,C_NET_ASP,CSS,HTML,Java,JavaScript,Python,Python_Flask")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,First_Name,Last_Name,Date_of_Birth,Location,Email,C_NET_ASP,CSS,HTML,Java,JavaScript,Python,Python_Flask")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Admin");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
            db.SaveChanges();
            return RedirectToAction("Admin");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
