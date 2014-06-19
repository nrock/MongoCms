using MongoCms.Data.Entity;
using MongoDB.Driver;

namespace MongoCms.Data
{
    public class MongoCmsRepository
    {

        public MongoDatabase Database;

        public MongoCmsRepository( )
        {
            const string connectionString = "mongodb://localhost";
            const string databaseName = "cms";
            //MongoCmsRepository(connectionString, databaseName);
            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            Database = server.GetDatabase(databaseName);
        }

        public MongoCmsRepository(string connectionString, string databaseName)
        {

            var client = new MongoClient(connectionString);
            var server = client.GetServer();
            Database = server.GetDatabase(databaseName);
        }


        public MongoCollection<Rental> Rentals
        {
            get
            {
                return Database.GetCollection<Rental>("rentals");
            }
        }

    }
}