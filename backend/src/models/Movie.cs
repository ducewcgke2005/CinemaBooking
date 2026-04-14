using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace CinemaBooking.models
{
    public class Movie
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonElement("title")]
        public string Title { get; set; }

        [BsonElement("description")]
        public string Description { get; set; }

        [BsonElement("duration")]
        public int Duration { get; set; }

        [BsonElement("genre")]
        public List<string> Genre { get; set; }

        [BsonElement("poster")]
        public string Poster { get; set; }

        [BsonElement("trailer")]
        public string Trailer { get; set; }

        [BsonElement("releaseDate")]
        public DateTime ReleaseDate { get; set; }

        [BsonElement("status")]
        public string Status { get; set; }

        [BsonElement("createdAt")]
        public DateTime CreatedAt { get; set; }
    }
}