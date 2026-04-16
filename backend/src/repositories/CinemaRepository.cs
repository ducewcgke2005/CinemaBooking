using CinemaBooking.data;
using CinemaBooking.models;
using MongoDB.Driver;

namespace CinemaBooking.repositories
{
    public class CinemaRepository
    {
        private readonly IMongoCollection<Cinema> _cinemas;

        public CinemaRepository(MongoDbContext context)
        {
            _cinemas = context.GetCollection<Cinema>("cinemas");
        }

        public async Task<List<Cinema>> GetAllAsync()
        {
            return await _cinemas.Find(_ => true).ToListAsync();
        }
        public async Task<Cinema> GetByIdAsync(string id)
        {
            return await _cinemas.Find(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Cinema cinema)
        {
            await _cinemas.InsertOneAsync(cinema);
        }
    }
}