using MongoDB.Driver;

namespace SheltersApp.Shared.Model
{
    public class BookingList
    {
        private IMongoCollection<Booking> _bookings;

        public BookingList(IMongoClient client)
        {
            var database = client.GetDatabase("shelterDB");
            _bookings = database.GetCollection<Booking>("bookings");
        }

        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookings.Find(_ => true).ToListAsync();
        }

        // Metode til at tilføje en ny booking kan også tilføjes her
        public async Task AddBookingAsync(Booking booking)
        {
            await _bookings.InsertOneAsync(booking);
        }
    }
}
