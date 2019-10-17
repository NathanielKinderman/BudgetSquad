﻿using BudgetSquad.Models;
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
            MadeActivites madeActivites = context.MadeActivites.FirstOrDefault(m => m.MadeActivitesId == id);
            var activitesSet = context.ActivitesInfos.Where(a => a.MadeActivitesId == id);
            List<DataPoint> dataPoints = new List<DataPoint>();
            foreach (ActivitesInfo point in activitesSet)
            {
                dataPoints.Add(new DataPoint(point.ActivityName, point.CostOfActivity));

            }


            ViewBag.DataPoints = JsonConvert.SerializeObject(dataPoints);

            return View();
        }
    }
}