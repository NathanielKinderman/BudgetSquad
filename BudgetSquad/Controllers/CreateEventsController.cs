using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;

namespace BudgetSquad.Models
{
    public class CreateEventsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: CreateEvents
        public ActionResult Index()
        {
            var createEvents = db.CreateEvents.Where(c => c.EventsName != null).ToList();
            return View(createEvents.ToList());
        }

        // GET: CreateEvents/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            return View(createEvent);
        }

        // GET: CreateEvents/Create
        public ActionResult Create()
        {
            CreateEvent createEvent = new CreateEvent();
            //ViewBag.PlannerId = new SelectList(db.Planners, "Id", "FirstName");
            return View();
        }

        // POST: CreateEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,EventsName,City,State,DateOfEvent,NumberOfMembers,TheBudgetOfEvent,Planner,ApplicationUserId")] CreateEvent createEvent)
        {
            if (ModelState.IsValid)
            {
                var currentPlannerId = User.Identity.GetUserId();
                Planner planner = new Planner();
                planner.ApplicationUserId = currentPlannerId;                
                db.CreateEvents.Add(createEvent);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.PlannerId = new SelectList(db.Planners, "Id", "FirstName", createEvent.PlannerId);
            return View(createEvent);
        }

        public ActionResult MadeActivites()
        {
            return View();

        }



        // GET: CreateEvents/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            //ViewBag.PlannerId = new SelectList(db.Planners, "Id", "FirstName", createEvent.PlannerId);
            return View(createEvent);
        }

        // POST: CreateEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,EventsName,City,State,DateOfEvent,NumberOfMembers,TheBudgetOfEvent,Planner,ApplicationUserId")] CreateEvent createEvent)
        {
            if (ModelState.IsValid)
            {
                db.Entry(createEvent).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.PlannerId = new SelectList(db.Planners, "Id", "FirstName", createEvent.PlannerId);
            return View(createEvent);
        }

        // GET: CreateEvents/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CreateEvent createEvent = db.CreateEvents.Find(id);
            if (createEvent == null)
            {
                return HttpNotFound();
            }
            return View(createEvent);
        }

        // POST: CreateEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CreateEvent createEvent = db.CreateEvents.Find(id);
            db.CreateEvents.Remove(createEvent);
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

        //public void sendEmail(Email email)
        //{
        //    email.Message = "Who created this Event?" + Environment.NewLine +
        //    "What is the Name of the Event you are creating?" + Environment.NewLine +
        //    "Test Event" + Environment.NewLine +
        //    "What city do you want to host this Event?" + Environment.NewLine +
        //    "Milwaukee" + Environment.NewLine +
        //    "State:" + Environment.NewLine +
        //    "WI" + Environment.NewLine +
        //    "What is the date of this event?" + Environment.NewLine +
        //    "10 /16/2019" + Environment.NewLine +
        //    "How many people are going to be invited" + Environment.NewLine +
        //    "8" + Environment.NewLine +
        //    "What is the total budget of this event" + Environment.NewLine +
        //    "1000.00";
        //    email.FirstName = "Nathaniel";
        //    email.LastName = "Kinderman";
        //    email.Subject = "Event Details";
        //    var currentContact = db.PartyMembers.Where(c => c.FirstName == email.FirstName && c.LastName == email.LastName).FirstOrDefault();
        //    var fromAddress = new MailAddress("budgetsquadtestplanner@gmail.com", "Budget Squad Test Planner");
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
        //        Credentials = new NetworkCredential("budgetsquadtestplanner", "Squad_01")
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
