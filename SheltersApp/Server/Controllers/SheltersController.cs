using Microsoft.AspNetCore.Mvc;
using SheltersApp.Shared.Model;
using SheltersApp.Shared.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using SheltersApp.Repositories;
using SheltersApp.Server.Repository;

[ApiController]
[Route("api/shelterSIU")]
public class SheltersController : ControllerBase
{
    private readonly IShelterRepository _repository;

    public SheltersController(IShelterRepository repository)
    {
        _repository = repository;
    }

    // Hent alle shelters
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shelter>>> GetShelters()
    {
        try
        {
            var shelters = await _repository.GetAllShelters();
            return Ok(shelters);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"En fejl opstod ved hentning af shelter data. Fejl: {ex.Message}");
        }
    }
}
