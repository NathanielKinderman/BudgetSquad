﻿using Microsoft.AspNet.Identity;
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
        public ActionResult Details(int id)
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
        public ActionResult Create(CreateEvent createEvent)
        {
            if (ModelState.IsValid)
            {
                var planner = db.Planners.Select(p => p.Id).FirstOrDefault();
                createEvent.PlannerId = planner;                
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
        public ActionResult Edit(int id)
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
        public ActionResult Edit(CreateEvent createEvent)
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
        public ActionResult Delete(int id)
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

        

    }
}
