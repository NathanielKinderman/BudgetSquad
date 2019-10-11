using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace BudgetSquad.Models
{
    public class ActivitesInfo
    {
        [Key]
        public int InfoId { get; set; }
        public string ActivityName { get; set; }
        public double CostOfActivity { get; set; }
        [ForeignKey("MadeActivites")]
        public int MadeActivitesId { get; set; }
        public MadeActivites MadeActivites { get; set; }


    }
}