using Microsoft.AspNetCore.Mvc;
using SheltersApp.Shared.Model;

[ApiController] // Angiver at denne klasse er en API-controller
[Route("api/bookings")] // Definerer ruten til denne controller
public class BookingsController : ControllerBase
{
    private readonly IBookingRepository _repository; // Repository-pattern injektion til databasemanipulation

    // Konstruktør der injicerer afhængigheden af IBookingRepository
    public BookingsController(IBookingRepository repository)
    {
        _repository = repository;
    }

    // Hent alle bookinger - HTTP GET metode
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        try
        {
            var bookings = await _repository.GetAllBookings();
            return Ok(bookings); // Returnerer en 200 OK respons med listen af bookinger
        }
        catch (System.Exception ex)
        {
            // Håndterer eventuelle undtagelser og returnerer en 500 Internal Server Error respons
            return StatusCode(500, $"En fejl opstod ved hentning af booking data. Fejl: {ex.Message}");
        }
    }

    [HttpGet]
    [Route("getby/{navn:alpha}")]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings(string alpha)
    {
        try
        {
            var bookings = await _repository.GetBookingsByShelterName(alpha);
            return Ok(bookings);
        }
        catch (System.Exception ex)
        {
            // Håndterer eventuelle undtagelser og returnerer en 500 Internal Server Error respons
            return StatusCode(500, $"En fejl opstod ved hentning af booking data. Fejl: {ex.Message}");
        }
    }

    // Opret en ny booking - HTTP POST metode
    [HttpPost]
    public async Task<IActionResult> OpretBooking([FromBody] Booking booking)
    {
        try
        {
            await _repository.AddBooking(booking);
            return Ok(); // Returnerer en 200 OK respons hvis oprettelse lykkes
        }
        catch (System.Exception ex)
        {
            // Håndterer eventuelle undtagelser og returnerer en 500 Internal Server Error respons
            return StatusCode(500, $"En fejl opstod ved oprettelse af booking. Fejl: {ex.Message}");
        }
    }

    // Slet en booking - HTTP DELETE metode
    [HttpDelete("{bookingId}")]
    public async Task<IActionResult> DeleteBooking(string bookingId)
    {
        try
        {
            await _repository.DeleteBooking(bookingId);
            return Ok(); // Returnerer en 200 OK respons hvis sletningen lykkes
        }
        catch (Exception ex)
        {
            // Håndterer eventuelle undtagelser og returnerer en 500 Internal Server Error respons
            return StatusCode(500, $"En fejl opstod ved sletning af booking. Fejl: {ex.Message}");
        }
    }

    // Yderligere metoder til at opdatere osv. kan tilføjes her efter behov
}