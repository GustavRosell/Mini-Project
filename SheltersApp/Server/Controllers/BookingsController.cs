using Microsoft.AspNetCore.Mvc;
using SheltersApp.Shared.Model;
using SheltersApp.Shared.Storage;
using System.Collections.Generic;
using System.Threading.Tasks;
using SheltersApp.Repositories;

[ApiController]
[Route("api/bookings")]
public class BookingsController : ControllerBase
{
    private readonly IBookingRepository _repository;

    public BookingsController(IBookingRepository repository)
    {
        _repository = repository;
    }

    // Hent alle bookinger
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Booking>>> GetBookings()
    {
        try
        {
            var bookings = await _repository.GetAllBookings();
            return Ok(bookings);
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"En fejl opstod ved hentning af booking data. Fejl: {ex.Message}");
        }
    }

    // Opret en ny booking
    [HttpPost]
    public async Task<IActionResult> OpretBooking([FromBody] Booking booking)
    {
        try
        {
            await _repository.AddBooking(booking);
            return Ok();
        }
        catch (System.Exception ex)
        {
            return StatusCode(500, $"En fejl opstod ved oprettelse af booking. Fejl: {ex.Message}");
        }
    }

    // Her kan du tilføje yderligere metoder til at opdatere, slette osv., baseret på din repository implementering
}
