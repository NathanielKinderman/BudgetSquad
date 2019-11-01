using BudgetSquad.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BudgetSquad.Controllers
{
    public class CheckingInController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            //var currentUser = db.PartyMembers.Where(x => x.Id == id).FirstOrDefault();
            //var isCheckedIn = db.PartyMembers.Count(currentUser.IsGoingToEvent)
            //    var checkInStatus = "true";
            //    var list = db.PartyMembers.Where(x => checkInStatus.Contains("true")).ToList();
            return View();
        }
        public ActionResult AttendingPartyMembers()
        {
            List<PartyMember> members = new List<PartyMember>();

            var partyMemberList = db.PartyMembers.Where(x => x.IsGoingToEvent == true).OrderBy(x => x.FirstName).ThenBy(x => x.LastName).ToList();


            ViewBag.partyList = partyMemberList;
            return View(partyMemberList);
         }
    }

}
