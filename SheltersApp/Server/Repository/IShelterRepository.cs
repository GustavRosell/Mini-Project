using System;
namespace SheltersApp.Server.Repository
{
	using SheltersApp.Shared.Model;
	using System.Collections.Generic;
	using System.Threading.Tasks;

	public interface IShelterRepository
	{
		Task<IEnumerable<Shelter>> GetAllShelters();
	}
}
