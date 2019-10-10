using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetSquad.Models
{
    public class Planner
    {   [Key]
        public int Id { get; set; }
        [Display(Name= "Full Name")]
        public string FullName { get; set; }
        public string EmailAddress { get; set; }
        [Display(Name = "Events Total Budget")]
        public string Budget { get; set; }



        [ForeignKey("ApplicationUser")]
        [Display(Name = "UserID")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}