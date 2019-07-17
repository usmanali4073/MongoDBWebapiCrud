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
        public void Insert(string table, Person record)
        {
            var collection = _db.GetCollection<Person>(table);
            collection.InsertOne(record);
        }

        public IQueryable<Person> GetCollection(string table)
        {
            var collection = _db.GetCollection<Person>(table);
            return collection.AsQueryable();

        }
        public Person GetObjectById(string table, Guid Id)
        {
            var collection = _db.GetCollection<Person>(table);
            var filter = Builders<Person>.Filter.Eq(x=>x.Id, Id);
            return collection.Find(filter).FirstOrDefault();

            

        }

        public void UpdateOrUpsert(string table, Guid Id, Person Record)
        {
            var collection = _db.GetCollection<Person>(table);
            var result = collection.ReplaceOne(new BsonDocument("_Id", Id), Record, new UpdateOptions{ IsUpsert = true});


        }

        public void Delete(string table, Guid Id)
        {
            var collection = _db.GetCollection<Person>(table);
            var filter = Builders<Person>.Filter.Eq(x=>x.Id, Id);
            collection.DeleteOne(filter);
        }


    }
}
