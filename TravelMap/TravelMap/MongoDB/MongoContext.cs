using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MongoDB.Driver;
using TravelMap.Models;

namespace TravelMap.MongoDB
{
    public class MongoContext
    {
        private readonly string usersConst = "Users";
        private readonly string connectionString = "mongodb://localhost";
        private MongoDatabase _dataBase;
        public MongoContext()
        {
            var mongoClient = new MongoClient(connectionString);
            var server = mongoClient.GetServer();
            var database = server.GetDatabase("TravelMap");
            _dataBase = database;
        }
        
        public MongoCollection<User> Users
        {
            get
            {
               return _dataBase.CollectionExists(usersConst) 
                    ? _dataBase.GetCollection<User>(usersConst)
                    : CreateCollection();
                
            }
        }

        public MongoCollection<User> CreateCollection()
        {
            _dataBase.CreateCollection(usersConst);
            return _dataBase.GetCollection<User>(usersConst);
        }
    }
}