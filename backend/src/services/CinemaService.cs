using CinemaBooking.models;
using CinemaBooking.repositories;

namespace CinemaBooking.services
{
    public class CinemaService
    {
        private readonly CinemaRepository _repo;

        public CinemaService(CinemaRepository repo)
        {
            _repo = repo;
        }

        public Task<List<Cinema>> GetAll()
        {
            return _repo.GetAllAsync();
        }

        public Task<Cinema> GetById(string id)
        {
            return _repo.GetByIdAsync(id);
        }
    }
}