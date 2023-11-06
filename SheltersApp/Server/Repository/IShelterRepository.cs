using SheltersApp.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

// Interface der definerer kontrakten for shelter repository
public interface IShelterRepository
{
    // Deklarerer en metode til at hente alle shelters
    Task<IEnumerable<Shelter>> GetAllShelters();
}
