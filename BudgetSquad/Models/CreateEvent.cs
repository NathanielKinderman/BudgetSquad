using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetSquad.Models
{
    public class CreateEvent
    {
        [Key]
        public int EventId { get; set; }
        [Required]
        [Display(Name = "What is the Name of the Event you are creating?")]
        public string EventsName { get; set; }
        
        [Display(Name ="Who created this Event?")]
        public string NameOfPlanner { get; set; }


        [Display(Name = "What city do you want to host this Event?")]
        public string City { get; set; }
        [Display(Name = "State")]
        public string State { get; set; }
        [Display(Name = "What is the date of this event")]
        public string DateOfEvent { get; set; }
        [Display(Name = "How many people are going to be invited")]
        public double NumberOfMembers { get; set; }
        [Display(Name = "What is the max budget of this event")]

        public double TheMaxBudgetOfEvent { get; set; }
        [Display(Name="What is the minimum budget of this event")]
        public double TheMinBudgetOfEvent { get; set; }

        [ForeignKey("Planner")]
        [Display(Name = "PlannerId")]
        public int PlannerId { get; set; }
        public Planner Planner { get; set; }


        [NotMapped]
        public string Latitude { get; set; }
        [NotMapped]
        public string Longitude { get; set; }
    }
}