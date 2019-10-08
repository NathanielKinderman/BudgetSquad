using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BudgetSquad.Models;

namespace BudgetSquad.Controllers
{
    public class MadeActivitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MadeActivites
        public ActionResult Index()
        {
            var madeActivites = db.MadeActivites.Include(m => m.Event);
            return View(madeActivites.ToList());
        }

        // GET: MadeActivites/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            return View(madeActivites);
        }

        // GET: MadeActivites/Create
        public ActionResult Create()
        {
            ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName");
            return View();
        }

        // POST: MadeActivites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NameOfActivity,LocationOfActivity,Latitude,Longitude,City,State,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity,EventId")] MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                db.MadeActivites.Add(madeActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
            return View(madeActivites);
        }

        // GET: MadeActivites/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
            return View(madeActivites);
        }

        // POST: MadeActivites/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NameOfActivity,LocationOfActivity,Latitude,Longitude,City,State,TimeOfActivity,HowManyMembersInvolved,EstimatedCostOfActivity,EventId")] MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                db.Entry(madeActivites).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
            return View(madeActivites);
        }

        // GET: MadeActivites/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            if (madeActivites == null)
            {
                return HttpNotFound();
            }
            return View(madeActivites);
        }

        // POST: MadeActivites/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MadeActivites madeActivites = db.MadeActivites.Find(id);
            db.MadeActivites.Remove(madeActivites);
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
    }
}
