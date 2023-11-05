using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SheltersApp.Shared.Model;

namespace SheltersApp.Shared.Model
{
    public class Booking
    {
        [BsonId] // MongoDB primær nøgle
        [BsonRepresentation(BsonType.ObjectId)] // Tillad MongoDB at konvertere fra og til ObjectId automatisk
        public string Id { get; set; } // MongoDB kræver en egenskab kaldet Id

        public string BookingID { get; set; }
        public string Name { get; set; }
        public string Telefonnr { get; set; }
        public string ShelterName { get; set; }
        public DateTime? StartDate { get; set; } 
        public DateTime? EndDate { get; set; }

        // Parameterløs konstruktør for MongoDB ? hvorfor ?
        public Booking() { }

        // Konstruktør til at oprette booking
        public Booking(string bookingID, string name, string telefonnr, string shelterName, DateTime? startDate, DateTime? endDate)
        {
            Id = bookingID; // Sætter MongoDB dokumentets Id // Usikker på om jeg overhovedet skal bruge det her? // update; ja, for det virker heller ikke med Shelter.cs hvis det ikke er der. databasen kan ikke tilgåes
            BookingID = bookingID;
            Name = name;
            Telefonnr = telefonnr;
            ShelterName = shelterName;
            StartDate = startDate;
            EndDate = endDate;
        }
    }
}
