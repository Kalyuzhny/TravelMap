using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMap.Models
{
    public class Country
    {
        [Required]
        public ObjectId Id { get; set; }
        [Required]
        public string Title { get; set; }

        [Required]
        public int VisitedTimes { get; set; }
    }
}