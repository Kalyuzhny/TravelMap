using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace TravelMap.Tests
{
    [TestClass]
    public class POCOTests
    {
        public POCOTests()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        class Person
        {
            public int Age { get; set; }
            public string Name { get; set; }

        }

        [TestMethod]
        public void POCOSerializer()
        {

            var firstPerson = new Person()
            {
                Age = 18,
                Name = "Pers"
            };

            Console.WriteLine(firstPerson.ToJson());
        }
    }
}
