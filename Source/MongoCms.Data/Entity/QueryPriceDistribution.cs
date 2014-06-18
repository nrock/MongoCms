
namespace MongoCms.Data.Entity
{
	using System.Collections;
	using System.Collections.Generic;
	using MongoDB.Bson;
	using MongoDB.Driver;

	public class QueryPriceDistribution
	{
		public IEnumerable<BsonDocument> Run(MongoCollection<Rental> rentals)
		{
			var priceRange = new BsonDocument(
				"$subtract",
				new BsonArray
				{
					"$Price",
					new BsonDocument(
						"$mod",
						new BsonArray{"$Price", 500})
				});
			var grouping = new BsonDocument(
				"$group", 
				new BsonDocument
				{
					{"_id", priceRange},
					{"count", new BsonDocument("$sum", 1)}
				});
			var sort = new BsonDocument(
				"$sort", 
				new BsonDocument("_id", 1)
				);
			var args = new AggregateArgs
			{
				Pipeline = new[] {grouping, sort}
			};
			return rentals.Aggregate(args);
		}
	}
}