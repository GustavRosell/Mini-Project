using MongoDB.Driver;
using SheltersApp.Shared.Model;
using SheltersApp.Shared.Storage;

public class BookingRepository : IBookingRepository
{
    private readonly IMongoCollection<Booking> _bookings;

    // Konstruktøren initialiserer forbindelsen til 'bookings' collection i MongoDB
    public BookingRepository(Persistency persistency)
    {
        var database = persistency.GetDatabase();
        _bookings = database.GetCollection<Booking>("bookings");
    }

    // Metode til at hente alle bookinger asynkront
    public async Task<IEnumerable<Booking>> GetBookingsByShelterName(string name)
    {
        return await _bookings.Find(b => b.ShelterName == name).ToListAsync();
    }

    // Metode til at hente alle bookinger asynkront
    public async Task<IEnumerable<Booking>> GetAllBookings()
    {
        return await _bookings.Find(_ => true).ToListAsync();
    }

    // Metode til at tilføje en ny booking asynkront
    public async Task AddBooking(Booking booking)
    {
        await _bookings.InsertOneAsync(booking);
    }

    // Metode til at slette en booking asynkront baseret på ID
    public async Task DeleteBooking(string bookingId)
    {
        await _bookings.DeleteOneAsync(b => b.BookingID == bookingId);
    }

    // Yderligere CRUD operationer som Update kan implementeres her
}
