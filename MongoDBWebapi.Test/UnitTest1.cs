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
                LastName = "Haniya",
                shippingAddress = new ShippingAddress
                {
                    ShippingAddressId = Guid.NewGuid(),
                    Address1 = "210 Terrace Drive",
                    Address2 = "",
                    ZipCode = "06066"

                },
                dateofTime = new DateTime(1992, 12, 11)
                
            };


            _db.Insert("Person", pr);
        }

        [Fact]
        public void GetCollection_Test()
        {
            var data = _db.GetCollection("Person").ToList();

        }
        [Fact]
        public void GetCollectionByName_Test()
        {
            var data = _db.GetCollection("Person").Where(x => x.FirstName.Contains("Tak")).ToList();

        }

        [Fact]
        public void GetCollecion_Upsert_Test()
        {
            //Arrange
            Guid id = Guid.Parse("ffd4c0a9-37a4-48c2-baae-75bbc5f7fe84");
            //Act
            var record = _db.GetObjectById("Person", id);
            record.dateofTime = new DateTime(1998, 12, 11);
            _db.UpdateOrUpsert("Person", record.Id, record);
            //Assert
            
        }
        [Fact]
        public void GetCollection_Delete_Test()
        {
            Guid id = Guid.Parse("036be584-23c5-491c-8bbb-8d6227ad4793");
            //Act
            _db.Delete("Person", id);
            //Assert
        }

    }
}
