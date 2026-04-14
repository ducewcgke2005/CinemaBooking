using CinemaBooking.models;
using CinemaBooking.repositories;

namespace CinemaBooking.services
{
    public class MovieService
    {
        private readonly MovieRepository _repo;

        public MovieService(MovieRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Movie>> GetAll()
        {
            return _repo.GetAllAsync();
        }
    }
}