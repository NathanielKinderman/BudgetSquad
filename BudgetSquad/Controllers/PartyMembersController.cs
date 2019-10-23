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
    public class PartyMembersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PartyMembers
        public ActionResult Index()
        {
            var partyMembers = db.PartyMembers.Include(p => p.ApplicationUser);
            return View(partyMembers.ToList());
        }

        // GET: PartyMembers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            return View(partyMember);
        }

        // GET: PartyMembers/Create
        public ActionResult Create()
        {
            PartyMember partyMember = new PartyMember();
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email");
            return View();
        }

        // POST: PartyMembers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,EmailAddress,PersonalBudget,ApplicationUserId")] Models.PartyMember partyMember)
        {
            if (ModelState.IsValid)
            {
                partyMember.IsGoingToEvent = true;
                db.PartyMembers.Add(partyMember);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", partyMember.ApplicationUserId);
            return View(partyMember);
        }

        // GET: PartyMembers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", partyMember.ApplicationUserId);
            return View(partyMember);
        }
        public ActionResult SeeExpenseChart()
        {

            return View();
        }

        // POST: PartyMembers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,EmailAddress,PersonalBudget,ApplicationUserId")] PartyMember partyMember)
        {
            if (ModelState.IsValid)
            {
                db.Entry(partyMember).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            //ViewBag.ApplicationUserId = new SelectList(db.ApplicationUsers, "Id", "Email", partyMember.ApplicationUserId);
            return View(partyMember);
        }

        // GET: PartyMembers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var partyMember = db.PartyMembers.Find(id);
            if (partyMember == null)
            {
                return HttpNotFound();
            }
            return View(partyMember);
        }

        // POST: PartyMembers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var partyMember = db.PartyMembers.Find(id);
            db.PartyMembers.Remove(partyMember);
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
