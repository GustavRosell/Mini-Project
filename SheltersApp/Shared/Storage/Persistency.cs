using MongoDB.Driver;

namespace SheltersApp.Shared.Storage
{
    public class Persistency
    {
        private readonly IMongoClient dbClient;
        private readonly IMongoDatabase database;

        // Constructor
        public Persistency()
        {
            string connectionString = "mongodb+srv://gustavrosell:Gustav41541@dbdesign.q2bkeja.mongodb.net/";
            dbClient = new MongoClient(connectionString);
            database = dbClient.GetDatabase("shelterdb");
        }

        public IMongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
