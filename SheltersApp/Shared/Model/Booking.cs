using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SheltersApp.Shared.Model
{
    public class Booking
    {
        [BsonId] // Markerer dette felt som den primære nøgle i MongoDB
        [BsonRepresentation(BsonType.ObjectId)] // Tillader automatisk konvertering mellem string og MongoDB's ObjectId
        public string? Id { get; set; } // Id-felt, som MongoDB bruger som primær nøgle

        public string BookingID { get; set; } = string.Empty; // 'Unikt' ID for bookingen
        public string Name { get; set; } = string.Empty; // Navnet på personen, der har foretaget bookingen
        public string Telefonnr { get; set; } = string.Empty; // Telefonnummer for kontaktperson
        public string ShelterName { get; set; } = string.Empty; // Navnet på shelteret der er booket
        public string StartDate { get; set; } = DateTime.Today.ToString("yyyy-MM-dd"); // Startdato for bookingen
        public string EndDate { get; set; } = DateTime.Today.AddDays(1).ToString("yyyy-MM-dd"); // Slutdato for bookingen

        // En parameterløs konstruktør er nødvendig for at MongoDB driveren kan deserialisere objekter
        public Booking() { }

        // Konstruktør til at oprette en ny booking med specifikke værdier
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
