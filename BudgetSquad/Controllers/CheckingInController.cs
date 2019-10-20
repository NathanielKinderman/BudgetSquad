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
        // GET: CheckingIn
        public ActionResult Index(int? id)
        {
            PartyMember partyMember = new PartyMember();
            bool HasCheckIn = partyMember.IsGoingToEvent;
            if(HasCheckIn == true)
            {

            }
            return View();
        }
        
    }
}