using BudgetingSquad.Models;
using BudgetSquad.Models;
using Newtonsoft.Json;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using System.Net.Mail;
using MailKit.Net.Smtp;
using MailKit;
using MimeKit;
using SmtpClient = System.Net.Mail.SmtpClient;

namespace BudgetSquad.Controllers
{
    public class MadeActivitesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: MadeActivites
        public ActionResult Index()
        {
            var madeActivites = db.MadeActivites.Where(m => m.EventsName != null).ToList();
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
            MadeActivites madeActivites = new MadeActivites();
            //ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName");
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
                int plannerId = db.Planners.Select(x => x.Id).FirstOrDefault();
                madeActivites.PlannerId = plannerId;
                db.MadeActivites.Add(madeActivites);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //ViewBag.EventId = new SelectList(db.CreateEvents, "Id", "EventsName", madeActivites.EventId);
            return View(madeActivites);
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



        public string ConvertAddressToGoogleFormat(Address address)
        {
            string googleFormatAddress = address.StreetAddress + "," + address.City + "," + address.State + "," + address.ZipCode + "," + address.Country;
            return googleFormatAddress;
        }

        public GeocodeInfo GeoLocate(string address)
        {

            var requestUrl = $"https://maps.googleapis.com/maps/api/geocode/json?address={address}&key=AIzaSyCgxbc-4DbwDz3-fH-pSijZdrbh6JL-i4E";
            var result = new WebClient().DownloadString(requestUrl);
            GeocodeInfo geocodeInfo = JsonConvert.DeserializeObject<GeocodeInfo>(result);
            return geocodeInfo;
        }

        public ActionResult Map()
        {
            return View();

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
