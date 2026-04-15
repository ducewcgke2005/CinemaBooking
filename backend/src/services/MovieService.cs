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

        public Task<Movie> GetById(string id)
        {
            return _repo.GetByIdAsync(id);
        }
    }
}