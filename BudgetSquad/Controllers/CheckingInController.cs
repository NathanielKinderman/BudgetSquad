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
            var checkInStatus = "true";
            var list = db.PartyMembers.Where(x => checkInStatus.Contains("true")).ToList();
            return View(list);
        }
        //public ActionResult Index()
        //{
        //    var partyMemberList = db.PartyMembers.Where(x => x.IsGoingToEvent == true).ToList();
        //    return View();
        //}

    }
}