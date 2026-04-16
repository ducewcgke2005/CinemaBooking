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
    }
}