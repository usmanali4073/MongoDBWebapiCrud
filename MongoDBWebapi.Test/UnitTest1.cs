using MongoDBWebApi.Domain;
using MongoDBWebApi.MongoDB;
using System;
using System.Diagnostics;
using System.Linq;
using Xunit;

namespace MongoDBWebapi.Test
{
    public class UnitTest1
    {
        public MongoCrud _db { get; set; }
        public UnitTest1()
        {
            _db = new MongoCrud("Library");
        }

        [Fact]
        public void InsertOne_Test()
        {

            Person pr = new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Takmeela",
                LastName = "Shafique",
                shippingAddress = new ShippingAddress
                {
                    ShippingAddressId = Guid.NewGuid(),
                    Address1 = "210 Terrace Drive",
                    Address2 = "",
                    ZipCode = "06066"
            
                }
            };


            _db.Insert<Person>("Person", pr);
        }

        [Fact]
        public void GetCollection_Test()
        {
            var data = _db.GetCollection<Person>("Person");

        }
        [Fact]
        public void GetCollectionByName_Test()
        {
            var data = _db.GetCollection<Person>("Person").Where(x=>x.FirstName.Contains("tak")).ToList();

        }

    }
}
