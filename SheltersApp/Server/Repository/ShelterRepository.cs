using MongoDB.Driver;
using SheltersApp.Shared.Model;
using SheltersApp.Shared.Storage;

public class ShelterRepository : IShelterRepository
{
    private readonly IMongoCollection<Shelter> _shelters;

    // Konstruktøren initialiserer forbindelsen til 'shelterSIU' collection i MongoDB
    public ShelterRepository(Persistency persistency)
    {
        var database = persistency.GetDatabase();
        _shelters = database.GetCollection<Shelter>("shelterSIU");
    }

    // Metode til at hente alle shelters asynkront
    public async Task<IEnumerable<Shelter>> GetAllShelters()
    {
        return await _shelters.Find(_ => true).ToListAsync();
    }
}
