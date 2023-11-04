using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SheltersApp.Shared.Model
{
    public class Shelter
    {
        [BsonId] // MongoDB primær nøgle
        [BsonRepresentation(BsonType.ObjectId)] // Tillad MongoDB at konvertere fra og til ObjectId automatisk
        public string Id { get; set; } // MongoDB kræver en egenskab kaldet Id

        [BsonElement("navn")]
        public string Navn { get; set; } = " ";

    }
}
