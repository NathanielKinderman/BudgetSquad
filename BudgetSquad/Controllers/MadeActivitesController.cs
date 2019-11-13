using BudgetingSquad.Models;
using BudgetSquad.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using SmtpClient = System.Net.Mail.SmtpClient;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BudgetSquad.Controllers
{
    public class MadeActivitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MadeActivites
        public ActionResult Index()
        {
            var budgetShown = db.CreateEvents.Select(c => c.TheMaxBudgetOfEvent).FirstOrDefault();
            var minBudget = db.CreateEvents.Select(m => m.TheMinBudgetOfEvent).FirstOrDefault();
            ViewBag.BudgetTitle = "The Events Max Budget";
            ViewBag.MinBudgetTitle = "The Events Min Budget";
            ViewBag.Budget = budgetShown;
            ViewBag.minBudget = minBudget;
            return View(db.MadeActivites.ToList());




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
            //var ActivityList = new List<string>() { "Food/Drink", "Entertainment", "Leisure" };
            //ViewBag.ActivityList = ActivityList;

            return View();
        }

        // POST: MadeActivites/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(MadeActivites madeActivites)
        {
            if (ModelState.IsValid)
            {
                //db.MadeActivites.Add(madeActivites);
                //db.SaveChanges();
                var plannerId = db.Planners.Select(x => x.Id).FirstOrDefault();
                //int createEventId = db.CreateEvents.Select(x => x.PlannerId).FirstOrDefault();
                madeActivites.PlannerId = plannerId;
                madeActivites.Country = "USA";
                var addressConvert = ConvertAddressToGoogleFormat(madeActivites);
                var geolocateInfo = GeoLocate(addressConvert);
                madeActivites.Latitude = geolocateInfo.results[0].geometry.location.lat;
                madeActivites.Longitude = geolocateInfo.results[0].geometry.location.lng;

                db.MadeActivites.Add(madeActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
            return View(madeActivites);
        }

        public GeoCode GeoLocate(string address)
        {
            var apiKey = Keys.APIKey;
            var requestUrl = "https://maps.googleapis.com/maps/api/geocode/json?address=" + address + "&key=" + apiKey;
            var result = new WebClient().DownloadString(requestUrl);
            GeoCode geocodeInfo = JsonConvert.DeserializeObject<GeoCode>(result);
            return geocodeInfo;
        }

        public ActionResult Map(int? id)
        {
            var lat = db.MadeActivites.Where(c => c.PlannerId == id).Select(c => c.Latitude).ToList();
            var lng = db.MadeActivites.Where(c => c.PlannerId == id).Select(c => c.Longitude).ToList();


            //var lng = currentUser.Longitude;
            //var results = lat + lng;
            ViewBag.Lat = lat;
            ViewBag.Lng = lng;
            return View();
        }
        public string ConvertAddressToGoogleFormat(MadeActivites madeActivites)
        {
            string googleFormatAddress = AddPluses(madeActivites.StreetAddress) + "," + AddPluses(madeActivites.City) + "," + AddPluses(madeActivites.StateAbbreviation) + "," + AddPluses(madeActivites.ZipCode) + "," + AddPluses(madeActivites.Country);
            return googleFormatAddress;
        }

        public string AddPluses(string str)
        {
            str = str.Replace(" ", "+");
            return str;
        }

        public ActionResult AddingCost(MadeActivites madeActivites)
        {


            var madeActivitesMaxCost = db.MadeActivites.Select(a => a.EstimatedCostOfActivity).FirstOrDefault();
            var madeActivitesMinCost = db.MadeActivites.Select(m => m.EstimatedMinimumCostOfActivity).FirstOrDefault();
            madeActivites.EstimatedCostOfActivity = madeActivitesMaxCost;
            madeActivites.EstimatedMinimumCostOfActivity = madeActivitesMinCost;
            ViewBag.MaxCost = madeActivitesMaxCost;
            ViewBag.MinCost = madeActivitesMinCost;

            return View();
        }
        public ActivitesInfo AddDataPoint(MadeActivites madeActivites)
        {
            ActivitesInfo activitesInfo = new ActivitesInfo();
            activitesInfo.ActivityName = madeActivites.NameOfActivity;
            activitesInfo.CostOfActivity = madeActivites.EstimatedCostOfActivity;
            activitesInfo.InfoId = madeActivites.MadeActivitesId;
            db.ActivitesInfos.Add(activitesInfo);
            db.SaveChanges();
            return activitesInfo;

        }

        public ActionResult Data()
        {
            return View();

        }

        //public ActionResult EventBrite()
        //{

        //    return View();
        //}

        public async Task EventBriteApi()
        {
            
            string url = $"https://www.eventbriteapi.com/v3/events/search/?token=BJQ5NU5V6KLU3BZ7R32V&location.address=milwaukee&location.within=10km&expand=venue";
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            string jsonResult = await response.Content.ReadAsStringAsync();
            
            if (response.IsSuccessStatusCode)
            {
                EventBrite eventBrite = JsonConvert.DeserializeObject<EventBrite>(jsonResult);
                 
                
               
            }
            
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
    //ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
    return View(madeActivites);
}

// POST: MadeActivites/Edit/5
// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
[HttpPost]
[ValidateAntiForgeryToken]
public ActionResult Edit(MadeActivites madeActivites)
{
    if (ModelState.IsValid)
    {
        db.Entry(madeActivites).State = EntityState.Modified;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    //ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
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


public ActionResult SendEmail()
{
    MailAddress fromAddress = new MailAddress("budgetsquadtestplanner@gmail.com", "Nate");
    MailAddress toAddress = new MailAddress("budgetsquadtestpartymember@gmail.com", "Bob");
    string myPassword = "Budget_1";
    string subject = "You Are Invited";
    string body = "You are invited to an Event from BudgetSquad. Please go to Bugdet Squad page and look the Event.";
    SmtpClient smtpServer = new SmtpClient
    {
        Host = "smtp.gmail.com",
        Port = 587,
        EnableSsl = true,
        DeliveryMethod = SmtpDeliveryMethod.Network,
        UseDefaultCredentials = false,
        Credentials = new NetworkCredential(fromAddress.Address, myPassword)
    };
    using (MailMessage message = new MailMessage(fromAddress, toAddress)
    {
        Subject = subject,
        Body = body
    })
    {
        smtpServer.Send(message);
    }
    return View();

}
    }
}
