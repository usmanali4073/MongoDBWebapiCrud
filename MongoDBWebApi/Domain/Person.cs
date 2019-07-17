using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MongoDBWebApi.Domain
{
    public class Person
    {
        [BsonId]
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ShippingAddress shippingAddress { get; set; }
        [BsonElement("dob")]
        public DateTime dateofTime { get; set; }
    }

    public class ShippingAddress
    {
        public Guid ShippingAddressId { get; set; }
        public string Address1 { get; set; }
        public string Address2 { get; set; }
        public string Town { get; set; }
        public string ZipCode { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

    }
}
