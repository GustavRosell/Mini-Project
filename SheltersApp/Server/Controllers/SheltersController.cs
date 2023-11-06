using Microsoft.AspNetCore.Mvc;
using SheltersApp.Shared.Model;

[ApiController] // Angiver at denne klasse er en API-controller
[Route("api/shelterSIU")] // Definerer ruten til denne controller
public class SheltersController : ControllerBase
{
    private readonly IShelterRepository _repository; // Repository-pattern injektion til databasemanipulation

    // Konstruktør der injicerer afhængigheden af IShelterRepository
    public SheltersController(IShelterRepository repository)
    {
        _repository = repository;
    }

    // Hent alle shelters - HTTP GET metode
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Shelter>>> GetShelters()
    {
        try
        {
            var shelters = await _repository.GetAllShelters();
            return Ok(shelters); // Returnerer en 200 OK respons med listen af shelters
        }
        catch (Exception ex)
        {
            // Håndterer eventuelle undtagelser og returnerer en 500 Internal Server Error respons
            return StatusCode(500, $"En fejl opstod ved hentning af shelter data. Fejl: {ex.Message}");
        }
    }

    // Yderligere metoder til at oprette, opdatere eller slette shelters kan tilføjes her
}
