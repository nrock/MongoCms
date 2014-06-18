namespace RealEstate.App_Start
{
	using MongoDB.Driver;
    using MongoCms.Properties;
    //using Rentals;

    public class MongoCmsContext
	{
		public MongoDatabase Database;

		public MongoCmsContext()
		{
			var client = new MongoClient(Settings.Default.ConnectionString);
			var server = client.GetServer();
            Database = server.GetDatabase(Settings.Default.MongoCmsDatabaseName);
		}

        //public MongoCollection<Rental> Rentals
        //{
        //    get
        //    {
        //        return Database.GetCollection<Rental>("rentals");
        //    }
        //}
	}
}







