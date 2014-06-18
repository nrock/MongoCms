using MongoCms.Data.Entity;
using MongoDB.Bson;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoCms.Data.Test.Entity
{

    [TestFixture]
    public class RentalTests : AssertionHelper
    {
        [Test]
        public void ToDocument_RentalWithPrice_PriceRepresentedAsDouble()
        {
            var rental = new Rental();
            rental.Price = 1;

            var document = rental.ToBsonDocument();

            Expect(document["Price"].BsonType, Is.EqualTo(BsonType.Double));
        }

        [Test]
        public void ToDocument_RentalWithAnId_IdIsRepresentedAsAnObjectId()
        {
            var rental = new Rental();
            rental.Id = ObjectId.GenerateNewId().ToString();

            var document = rental.ToBsonDocument();

            Expect(document["_id"].BsonType, Is.EqualTo(BsonType.ObjectId));
        }
    }
}
