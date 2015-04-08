using MongoDB.Driver.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TravelMap.Models;
using TravelMap.Monads;
using TravelMap.MongoDB;

namespace TravelMap.Controllers
{
    public class MapController : Controller
    {
        string _userName = "dmka";

        private MongoContext dbContext = new MongoContext();

        // GET: Map
        public ActionResult Index()
        {
            if (dbContext.Users != null)
            {
                
                var users = dbContext.Users.FindAll().ToList();

                return View(users);
            }
            return View();
        }

        public ActionResult Map()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create(List<Country> countries)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Country country)
        {
            bool userExist = true;
            var user = FindUser(_userName);

            if (user == null)
            {
                userExist = false;
                user = new User() {
                    UserName = _userName,
                    VisitedCountries = new List<Country>()
                };
            }

            AddCountryToUser(user, country);

            var result = userExist 
                ? dbContext.Users.Save(user)
                : dbContext.Users.Insert(user);
            var status = result
                .With(x => x.Response[0]).ToInt32();                
            if (status == 1)
            {
                return View("Index");
            }
            return View();
        }

        public User FindUser(string userName)
        {
            var query = Query<User>.EQ(e => e.UserName, userName);
            return dbContext.Users.FindOne(query);
        }

        public void AddCountryToUser(User user, Country country)
        {
            var userHasCountry = user.VisitedCountries.Any(x => x.Title == country.Title);

            if(userHasCountry)
            {
                var userCountry = user.VisitedCountries.First(x => x.Title == country.Title);
                userCountry.VisitedTimes += country.VisitedTimes;
            }
            else
            {
                user.VisitedCountries.Add(country);
            }

        }

    }
}