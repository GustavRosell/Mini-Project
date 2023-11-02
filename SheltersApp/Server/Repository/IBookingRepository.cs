namespace SheltersApp.Repositories
{
    using SheltersApp.Shared.Model;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IBookingRepository
    {
        Task<IEnumerable<Booking>> GetAllBookings();
        Task AddBooking(Booking booking);
        // Andre metoder som Update, Delete kan også tilføjes her
    }
}