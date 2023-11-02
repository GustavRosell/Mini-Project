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
        public string Location { get; set; }

        // Konstruktør til at oprette en booking kan tilføjes her
        public Booking(string bookingID, string name, string location)
        {
            Id = bookingID; // Sætter MongoDB dokumentets Id // Usikker på om jeg overhovedet skal bruge det her?
            BookingID = bookingID;
            Name = name;
            Location = location;
        }
    }
}