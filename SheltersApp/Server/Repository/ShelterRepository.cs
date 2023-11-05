using System;
namespace SheltersApp.Server.Repository
{
    using MongoDB.Driver;
    using SheltersApp.Shared.Model;
    using SheltersApp.Shared.Storage;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class ShelterRepository : IShelterRepository
	{
        private readonly IMongoCollection<Shelter> _shelters;

		public ShelterRepository(Persistency persistency)
        {
            var database = persistency.GetDatabase();
            _shelters = database.GetCollection<Shelter>("shelterSIU");
        }

        public async Task<IEnumerable<Shelter>> GetAllShelters()
        {
            return await _shelters.Find(_ => true).ToListAsync();
        }
    }
}
