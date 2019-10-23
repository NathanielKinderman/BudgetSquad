using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using BudgetingSquad.Models;

namespace BudgetSquad.Models
{
    public class MadeActivites
    {
        [Key]
        public int MadeActivitesId { get; set; }
        [Display(Name ="What Kind of Activity is this?")]
        public string TypeOfActivity { get; set; }
        
        [Required]
        [Display(Name = "What is the Name of the Event that is Activity is for?")]
        public  string EventsName { get; set; }
        [Display(Name = "Whats the Name of Activity?")]
        public string NameOfActivity { get; set; }
        [Display(Name = "What is the Address of this Activity?")]
        public string LocationOfActivity { get; set; }
        [Display(Name = "What Time is the Activity happening?")]
        public string Latitude { get; set; }
        public string Longitude { get; set; }
        [Display(Name = "City")]
        public string City { get; set; }

        [Display(Name = "State")]
        public string State { get; set; }
        public string TimeOfActivity { get; set; }
        [Display(Name = "How many people do you plan on going to this event?")]
        public string HowManyMembersInvolved { get; set; }
        [Display(Name = "How much do you think this Activity is going to cost?")]
        public double EstimatedCostOfActivity { get; set; }
        [Display(Name= "How much do you think what is the minimum amount you will spend?")]
        public double EstimatedMinimumCostOfActivity { get; set; }
        [Display(Name = "Would you come to this Activity?")]
        public bool CheckingInToActivity { get; set; }

        [ForeignKey("Planner")]
        [Display(Name = "PlannerId")]
        public int PlannerId { get; set; }
        public Planner Planner { get; set; }
    }
}