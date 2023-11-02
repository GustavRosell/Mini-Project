namespace SheltersApp.Repositories
{
    using MongoDB.Driver;
    using SheltersApp.Shared.Model;
    using SheltersApp.Shared.Storage;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class BookingRepository : IBookingRepository
    {
        private readonly IMongoCollection<Booking> _bookings;

        public BookingRepository(Persistency persistency)
        {
            var database = persistency.GetDatabase();
            _bookings = database.GetCollection<Booking>("bookings");
        }

        public async Task<IEnumerable<Booking>> GetAllBookings()
        {
            return await _bookings.Find(_ => true).ToListAsync();
        }

        public async Task AddBooking(Booking booking)
        {
            await _bookings.InsertOneAsync(booking);
        }

        // Implementér andre metoder som Update, Delete her
    }
}