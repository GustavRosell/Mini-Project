using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using SheltersApp.Shared.Model;

namespace SheltersApp.Shared.Model
{
    public class Booking
    {
        [BsonId] // MongoDB primær nøgle
        [BsonRepresentation(BsonType.ObjectId)] // Tillad MongoDB at konvertere fra og til ObjectId automatisk
        public int Id { get; set; } // MongoDB kræver en egenskab kaldet Id

        public int BookingID { get; set; }
        public string Name { get; set; }
        public int Telefonnr { get; set; }
        public string ShelterName { get; set; }

        // Konstruktør til at oprette en booking kan tilføjes her
        public Booking(int bookingID, string name, int telefonnr, string shelterName)
        {
            Id = bookingID; // Sætter MongoDB dokumentets Id // Usikker på om jeg overhovedet skal bruge det her? // update; ja, for det virker heller ikke med Shelter.cs hvis det ikke er der. databasen kan ikke tilgåes
            BookingID = bookingID;
            Name = name;
            Telefonnr = telefonnr;
            ShelterName = shelterName;
        }
    }
}
