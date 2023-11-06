using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SheltersApp.Shared.Model
{
    public class Shelter
    {
        [BsonId] // MongoDB primær nøgle
        [BsonRepresentation(BsonType.ObjectId)] // Tillad MongoDB at konvertere fra og til ObjectId automatisk
        public string? Id { get; set; } // MongoDB kræver en egenskab kaldet Id

        [BsonElement("navn")]
        public string Navn { get; set; } = " "; // Navn på shelteret

        [BsonElement("lang_beskr")]
        public string Lang_beskr { get; set; } = " "; // Lang beskrivelse af shelteret

        [BsonElement("beskrivels")]
        public string Beskrivelse { get; set; } = " "; // Kort beskrivelse af shelteret // ikke brugt

        [BsonElement("status")]
        public string Status { get; set; } = " "; // Status for shelteret (f.eks. ledig, optaget) // ikke brugt
    }
}
