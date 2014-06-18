 

namespace MongoCms.Web.Test
{
    using System;
    using System.Collections.Generic;
    using MongoDB.Bson;
    using MongoDB.Bson.IO;
    using MongoDB.Bson.Serialization.Attributes;
    using NUnit.Framework;

    public class PocoTests
    {
        public PocoTests()
        {
            JsonWriterSettings.Defaults.Indent = true;
        }

        public class Person
        {
            public string FirstName { get; set; }
            public int Age { get; set; }

            public List<string> Address = new List<string>();
            public Contact Contact = new Contact();
            [BsonIgnore]
            public string IgnoreMe { get; set; }
            [BsonElement("New")]
            public string Old { get; set; }
            [BsonElement]
            private string Encapsulated;
        }

        public class Contact
        {
            public string Email { get; set; }
            public string Phone { get; set; }
        }

        [Test]
        public void SerializationAttributes()
        {
            var person = new Person();

            Console.WriteLine(person.ToJson());
        }

        [Test]
        public void Automatic()
        {
            var person = new Person
            {
                Age = 54,
                FirstName = "bob"
            };
            person.Address.Add("101 Some Road");
            person.Address.Add("Unit 501");
            person.Contact.Email = "email@email.com";
            person.Contact.Phone = "123-456-7908";

            Console.WriteLine(person.ToJson());
        }
    }
}
