using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BudgetSquad.Models.EventsViewModel
{
    public class ManageEventsViewModel
    {
        public Planner Planner { get; set; }
        public CreateEvent CreateEvent { get; set; }
        public MadeActivites MadeActivites { get; set; }
        public List<CreateEvent> GetAllEvents { get; set; }
        public List<MadeActivites> GeAllactivites { get; set; }
    }
}