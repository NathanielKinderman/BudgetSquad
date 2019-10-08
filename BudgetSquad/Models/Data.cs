﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace BudgetSquad.Models
{
    public class Data
    {
        //DataContract for Serializing Data - required to serve in JSON format

        [DataContract]
        public class DataPoint
        {
            [Key]
            public int Id { get; set; }
            public DataPoint(string x, double y)
            {
                this.X = x;
                this.Y = y;
            }

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "x")]
            public string X = null;

            //Explicitly setting the name to be used while serializing to JSON.
            [DataMember(Name = "y")]
            public double? Y = null;

            [ForeignKey("MadeActivites")]
            public int MadeActivitesId { get; set; }
            public MadeActivites MadeActivites { get; set; }
        }
    }   
}