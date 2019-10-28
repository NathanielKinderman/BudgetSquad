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
            var typeOfActivity = context.MadeActivites.Select(t => t.TypeOfActivity).ToList();
            var foodDrink = typeOfActivity.Where(f => f.Contains("Food/Drink")).ToList();
            string nameOfActivity = currentUser.NameOfActivity;
            double estimatedCost = currentUser.EstimatedCostOfActivity;
            double minCost = currentUser.EstimatedMinimumCostOfActivity;
            //var typeOfActivity = currentUser.Select(d => d.Contains("Food/Drink")).ToLIst();
            ViewBag.typeofActivity = JsonConvert.SerializeObject(foodDrink);
            ViewBag.nameOfActivity = nameOfActivity;
            ViewBag.estimatedCost = JsonConvert.SerializeObject(estimatedCost);
            ViewBag.minCost = JsonConvert.SerializeObject(minCost);
            return View();

            ////this matches the PlannerId of the current user
            //MadeActivites currentUser = context.MadeActivites.Where(x => x.PlannerId == id).FirstOrDefault();

            ////declaring local variables
            //double estimatedCost = currentUser.EstimatedCostOfActivity;
            //var typeOfActivity = currentUser.TypeOfActivity;

            ////query for typeofActivity
            //var foodDrink = context.MadeActivites.Where(x => x.TypeOfActivity.Contains("Food/Drink")).Distinct();
            //var leisure = context.MadeActivites.Where(x => x.TypeOfActivity.Contains("Leisure")).First();
            //var entertainment = context.MadeActivites.Where(x => x.TypeOfActivity.Contains("Entertainment")).First();


            ////this sends the variables to the view
            //ViewBag.foodDrink =foodDrink;
            //ViewBag.leisure = JsonConvert.SerializeObject(leisure);
            //ViewBag.entertainment = JsonConvert.SerializeObject(entertainment);
            //ViewBag.estimatedCost = JsonConvert.SerializeObject(estimatedCost);
            //return View();

            ////this matches the PlannerId of the current user
            //MadeActivites currentUser = context.MadeActivites.Where(x => x.PlannerId == id).FirstOrDefault();
            ////declaring variables
            //double estimatedCost = currentUser.EstimatedCostOfActivity;
            //var typeOfActivity = currentUser.TypeOfActivity;
            //var foodDrinkActivity = "Food/Drink";
            ////query for typeOfActivity
            //var foodDrink = context.MadeActivites.Where(x => typeOfActivity.Contains("Food/Drink")).Select(x => foodDrinkActivity);
            ////this sends the variables to the view
            //ViewBag.foodDrink = JsonConvert.SerializeObject(foodDrink);
            //ViewBag.estimatedCost = JsonConvert.SerializeObject(estimatedCost);
            //return View();

        }

        public ActionResult ActivitiesBreakdown(int? id)
        {
            MadeActivites currentUser = context.MadeActivites.Where(x => x.PlannerId == id).FirstOrDefault();
            var typeofActivity = context.MadeActivites.Select(d => d.TypeOfActivity).ToList();

            var foodDrink = typeofActivity.Where(f => f.Contains("Food/Drink")).ToList();
            int foodDrinkCount = foodDrink.Count();
            ViewBag.foodDrink = JsonConvert.SerializeObject(foodDrinkCount);

            var entertainment = typeofActivity.Where(e => e.Contains("Entertainment")).ToList();
            int entertainmentCount = entertainment.Count();
            ViewBag.entertainment = JsonConvert.SerializeObject(entertainmentCount);

            var leisure = typeofActivity.Where(l => l.Contains("Leisure")).ToList();
            int leisureCount = leisure.Count();
            ViewBag.leisure = JsonConvert.SerializeObject(leisureCount);
            
            return View();


        }


        public ActionResult VotingResultsForEntertainment(int? id)
        {
            var member = context.PartyMembers.Where(s => s.Id == id).FirstOrDefault();
            var entertainmentResults = context.PartyMembers.Select(e => e.EntertainmentList).ToList();

            var bar = entertainmentResults.Where(b => b.Contains("Bars")).ToList();
            int barCount = bar.Count();
            ViewBag.bar = JsonConvert.SerializeObject(barCount);

            var sport = entertainmentResults.Where(s => s.Contains("Sport Event")).ToList();
            int sportCount = sport.Count();
            ViewBag.sport = JsonConvert.SerializeObject(sportCount);

            var threater = entertainmentResults.Where(t => t.Contains("Threater/Concert")).ToList();
            int threaterCount = threater.Count();
            ViewBag.threater = JsonConvert.SerializeObject(threaterCount);

            var dancing = entertainmentResults.Where(d => d.Contains("Dancing")).ToList();
            int dancingCount = dancing.Count();
            ViewBag.dancing = JsonConvert.SerializeObject(dancingCount);

            var other = entertainmentResults.Where(o => o.Contains("Other")).ToList();
            int otherCount = other.Count();
            ViewBag.other = JsonConvert.SerializeObject(otherCount);

            return View();
            
        }
        public ActionResult VotingResultsForFoodDrink(int? id)
        {
            var member = context.PartyMembers.Where(s => s.Id == id).FirstOrDefault();
            var foodResults = context.PartyMembers.Select(e => e.FoodDrinkList).ToList();

            var burgers = foodResults.Where(b => b.Contains("Burgers")).ToList();
            int burgersCount = burgers.Count();
            ViewBag.burgers = JsonConvert.SerializeObject(burgersCount);

            var italian = foodResults.Where(i => i.Contains("Italian")).ToList();
            int italianCount = italian.Count();
            ViewBag.italian = JsonConvert.SerializeObject(italianCount);

            var sushi = foodResults.Where(s => s.Contains("Sushi")).ToList();
            int sushiCount = sushi.Count();
            ViewBag.sushi = JsonConvert.SerializeObject(sushiCount);

            var mexican = foodResults.Where(m => m.Contains("Mexican")).ToList();
            int mexicanCount = mexican.Count();
            ViewBag.mexican = JsonConvert.SerializeObject(mexicanCount);

            var other = foodResults.Where(o => o.Contains("Other")).ToList();
            int otherCount = other.Count();
            ViewBag.other = JsonConvert.SerializeObject(otherCount);

            return View();

        }

        public ActionResult VotingResultsForLeisure(int? id)
        {
            var member = context.PartyMembers.Where(s => s.Id == id).FirstOrDefault();
            var leisureResults = context.PartyMembers.Select(e => e.LeisureList).ToList();

            var spa = leisureResults.Where(s => s.Contains("Spa/Health")).ToList();
            int spaCount = spa.Count();
            ViewBag.spa = JsonConvert.SerializeObject(spaCount);

            var museum = leisureResults.Where(m => m.Contains("Museum")).ToList();
            int museumCount = museum.Count();
            ViewBag.museum = JsonConvert.SerializeObject(museumCount);

            var outdoor = leisureResults.Where(o => o.Contains("Outdoor Activites")).ToList();
            int outdoorCount = outdoor.Count();
            ViewBag.outdoor = JsonConvert.SerializeObject(outdoorCount);

            var other = leisureResults.Where(o => o.Contains("Other")).ToList();
            int otherCount = other.Count();
            ViewBag.other = JsonConvert.SerializeObject(otherCount);

            return View();

        }
    }
}