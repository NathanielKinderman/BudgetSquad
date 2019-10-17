using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetSquad.Models;
using System.Net.Mail;

namespace BudgetSquad.Controllers
{
    public class PlannersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Planners
        public ActionResult Index()
        {
            var planners = db.Planners.Include(p => p.ApplicationUser);
            return View(planners.ToList());
        }

        // GET: Planners/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // GET: Planners/Create
        public ActionResult Create()
        {
            Planner planner = new Planner();
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: Planners/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,fullName,EmailAddress,Budget,ApplicationUserId")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                db.Planners.Add(planner);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", planner.ApplicationUserId);
            return View(planner);
        }

        // GET: Planners/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", planner.ApplicationUserId);
            return View(planner);
        }

        // POST: Planners/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FullName,EmailAddress,Budget,ApplicationUserId")] Planner planner)
        {
            if (ModelState.IsValid)
            {
                db.Entry(planner).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", planner.ApplicationUserId);
            return View(planner);
        }

        // GET: Planners/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Planner planner = db.Planners.Find(id);
            if (planner == null)
            {
                return HttpNotFound();
            }
            return View(planner);
        }

        // POST: Planners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Planner planner = db.Planners.Find(id);
            db.Planners.Remove(planner);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        //[HttpPost]
        //public void sendEmail(Email email)
        //{
        //    var currentContact = db.PartyMembers.Where(c => c.FirstName == email.FirstName && c.LastName == email.LastName).FirstOrDefault();
        //    var fromAddress = new MailAddress("budgetsquadtestplanner", "Budget Squad Test Planner");
        //    var toAddress = new MailAddress($"{currentContact.EmailAddress}", $"{currentContact.FirstName} {currentContact.LastName}");
        //    string password = "Squad_1";
        //    string subject = email.Subject;
        //    string body = email.Message;

        //    var smtp = new SmtpClient
        //    {
        //        Host = "smtp.gmail.com",
        //        Port = 587,
        //        EnableSsl = true,
        //        DeliveryMethod = SmtpDeliveryMethod.Network,
        //        UseDefaultCredentials = false,
        //        Credentials = new NetworkCredential("budgetsquadtestplanner", password)
        //    };

        //    using (var message = new MailMessage(fromAddress, toAddress))
        //    {
        //        string Subject = subject;
        //        body = email.Message;
        //    }
        //    {
        //        smtp.Send(fromAddress.Address, toAddress.Address, subject, body);
        //    }



        //}
    }
}