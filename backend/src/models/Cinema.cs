using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CinemaBooking.models
{
    public class Cinema
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("location")]
        public string Location { get; set; }

        [BsonElement("address")]
        public string Address { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}