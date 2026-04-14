using CinemaBooking.models;
using CinemaBooking.repositories;

namespace CinemaBooking.services
{
    public class AuthService
    {
        private readonly UserRepository _repo;

        public AuthService(UserRepository repo)
        {
            _repo = repo;
        }

        public async Task<User> Login(string userName, string password)
        {
            var user = await _repo.GetByUserName(userName);
            Console.WriteLine($"LOGIN: {userName} - {password}");

            if (user == null || user.Password != password)
                return null;

            return user;
        }
    }
}