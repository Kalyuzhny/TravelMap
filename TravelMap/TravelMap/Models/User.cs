using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TravelMap.Models
{
    public class User
    {
        public ObjectId Id { get; set; }

        [Required]
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }

        public IList<Country> VisitedCountries { get; set; }

    }
}