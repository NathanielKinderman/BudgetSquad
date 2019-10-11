using BudgetSquad.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static BudgetSquad.Models.BarGraphData;

namespace BudgetSquad.Controllers
{
    public class DataController : Controller
    {
        
        
        public ActionResult Index()
        {
          
            return View();
        }
    }
}