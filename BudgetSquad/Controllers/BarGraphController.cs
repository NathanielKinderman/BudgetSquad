using BudgetSquad.Models;
using Microsoft.AspNet.Identity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BudgetSquad.Models.BarGraphData;

namespace BudgetSquad.Controllers
{
    public class BarGraphController : Controller
    {
        ApplicationDbContext context = new ApplicationDbContext();
        // GET: Home
        public ActionResult Index(int? id)
        {
            MadeActivites currentUser = context.MadeActivites.Where(x => x.PlannerId == id).FirstOrDefault();
            string nameOfActivity = currentUser.NameOfActivity;
            double estimatedCost = currentUser.EstimatedCostOfActivity;
            ViewBag.nameOfActivity = nameOfActivity;
            ViewBag.estimatedCost = JsonConvert.SerializeObject(estimatedCost);
            return View();


        }

        public ActionResult ActivitiesBreakdown(int? id)
        {
            MadeActivites currentUser = context.MadeActivites.Where(x => x.PlannerId == id).FirstOrDefault();
            string typeOfActivity = currentUser.TypeOfActivity;
            double estimatedCost = currentUser.EstimatedCostOfActivity;
            ViewBag.TypeOfActivity = typeOfActivity;
            ViewBag.estimatedCost = JsonConvert.SerializeObject(estimatedCost);
            return View();


        }
    }
}