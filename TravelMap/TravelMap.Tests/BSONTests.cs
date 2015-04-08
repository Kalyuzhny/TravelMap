using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TravelMap;
using MongoDB.Bson;
using MongoDB.Bson.IO;

namespace TravelMap.Tests
{
    [TestClass]
    public class BSONTests
    {
        public BSONTests()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        [TestMethod]
        public void EmptyDocument()
        {
            var document = new BsonDocument();

            Console.WriteLine(document);
        }

        [TestMethod]
        public  void AddElement()
        {
            var document = new BsonDocument();
            document.Add("FirstElement", new BsonInt32(1));

            Console.WriteLine(document);
        }
    }
}
