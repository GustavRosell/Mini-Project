using MongoDB.Driver;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SheltersApp.Shared.Model
{
    public class BookingList
    {
        private IMongoCollection<Booking> _bookings; // MongoDB collection af bookingobjekter

        // Konstruktøren initialiserer forbindelsen til databasen og sætter collection
        public BookingList(IMongoClient client)
        {
            var database = client.GetDatabase("shelterDB");
            _bookings = database.GetCollection<Booking>("bookings");
        }

        // Asynkron metode til at hente alle bookinger fra databasen
        public async Task<List<Booking>> GetAllBookingsAsync()
        {
            return await _bookings.Find(_ => true).ToListAsync();
        }

        // Asynkron metode til at tilføje en ny booking til databasen
        public async Task AddBookingAsync(Booking booking)
        {
            await _bookings.InsertOneAsync(booking);
        }
    }
}
