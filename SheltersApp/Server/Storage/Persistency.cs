using MongoDB.Driver;

namespace SheltersApp.Shared.Storage
{
    public class Persistency
    {
        private readonly IMongoClient dbClient; // Klient til at interagere med MongoDB server
        private readonly IMongoDatabase database; // Database objekt til at udføre operationer på databasen

        // Konstruktøren opretter forbindelse til databasen med den givne forbindelsesstreng
        public Persistency()
        {
            // forbindelsesstreng
            string connectionString = "mongodb+srv://gustavrosell:Gustav41541@dbdesign.q2bkeja.mongodb.net/";
            dbClient = new MongoClient(connectionString);
            database = dbClient.GetDatabase("shelterdb");
        }

        // Metode til at hente MongoDB-databaseobjektet
        public IMongoDatabase GetDatabase()
        {
            return database;
        }
    }
}
