using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDBWebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBWebApi.MongoDB
{
    public class MongoCrud
    {
        IMongoDatabase _db;
        public MongoCrud(string database)
        {
            var client = new MongoClient();
            _db = client.GetDatabase(database);
        }
        public void Insert<T>(string table, T record)
        {
            var collection = _db.GetCollection<T>(table);
            collection.InsertOne(record);
        }
      
        public IQueryable<T> GetCollection<T>(string table)
        {
            var collection = _db.GetCollection<T>(table);
            return collection.AsQueryable();
            
        }

    }
}
