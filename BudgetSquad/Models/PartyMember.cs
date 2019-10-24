using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetSquad.Models
{
    public class PartyMember
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "Email Address")]
        public string EmailAddress { get; set; }
        [Display(Name = "Personal Budget for the Event")]
        public string PersonalBudget { get; set; }
        public bool IsGoingToEvent { get; set; }

        [Display(Name = "What type of food would you like to Dine?")]
        public string FoodDrinkList { get; set; }

        [Display(Name = "What kind of Entertainment would you go to?")]
        public string EntertainmentList { get; set; }

        [Display(Name ="What kind of Leisurely Activity would you enjoy?")]
        public string LeisureList { get; set; }

        public List<PartyMember> Members { get; set; }

        [ForeignKey("ApplicationUser")]
        [Display(Name = "UserID")]
        public string ApplicationUserId { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}