using SheltersApp.Shared.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

// Interface der definerer kontrakten for booking repository
public interface IBookingRepository
{
    // Deklarerer en metode til at hente alle bookinger
    Task<IEnumerable<Booking>> GetAllBookings();

    // Deklarerer en metode til at tilføje en booking
    Task AddBooking(Booking booking);

    // Deklarerer en metode til at slette en booking baseret på ID
    Task DeleteBooking(string bookingId);

    Task <IEnumerable<Booking>> GetBookingsByShelterName(string name);
}
