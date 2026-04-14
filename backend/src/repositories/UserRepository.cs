using CinemaBooking.data;
using CinemaBooking.models;
using MongoDB.Driver;

namespace CinemaBooking.repositories
{
    public class UserRepository
    {
        private readonly IMongoCollection<User> _users;

        public UserRepository(MongoDbContext context)
        {
            _users = context.GetCollection<User>("users");
        }

        public async Task<User> GetByUserName(string userName)
        {
            return await _users.Find(u => u.UserName == userName).FirstOrDefaultAsync();
        }
    }
}