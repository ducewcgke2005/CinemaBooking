using CinemaBooking.data;
using CinemaBooking.models;
using MongoDB.Driver;

namespace CinemaBooking.repositories
{
    public class MovieRepository
    {
        private readonly IMongoCollection<Movie> _movies;

        public MovieRepository(MongoDbContext context)
        {
            _movies = context.GetCollection<Movie>("movies");
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            return await _movies.Find(_ => true).ToListAsync();
        }

        public async Task<Movie> GetByIdAsync(string id)
        {
            return await _movies.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Movie movie)
        {
            await _movies.InsertOneAsync(movie);
        }

        public async Task<bool> UpdateStatusAsync(string id, string status)
        {
            var filter = Builders<Movie>.Filter.Eq("_id", new ObjectId(id));
            var update = Builders<Movie>.Update.Set(x => x.Status, status);

            var result = await _movies.UpdateOneAsync(filter, update);

            return result.ModifiedCount > 0;
        }
    }
}