using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SheltersApp.Shared.Model;

namespace SheltersApp.Shared.Model
{
    public class Booking
    {
        [BsonId] // MongoDB primær nøgle
        [BsonRepresentation(BsonType.ObjectId)] // Tillad MongoDB at konvertere fra og til ObjectId automatisk
        public string? Id { get; set; } // MongoDB kræver en egenskab kaldet Id

        public string BookingID { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Telefonnr { get; set; } = string.Empty;
        public string ShelterName { get; set; } = string.Empty;
        public string StartDate { get; set; } = DateTime.Today.ToString("yyyy-MM-dd");
        public string EndDate { get; set; } = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd");

        // Parameterløs konstruktør for MongoDB ? hvorfor ?
        public Booking() { }

        // Konstruktør til at oprette booking
        public Booking(string bookingID, string name, string telefonnr, string shelterName, string startDate, string endDate)
        {
            Id = bookingID;
            BookingID = bookingID;
            Name = name;
            Telefonnr = telefonnr;
            ShelterName = shelterName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
