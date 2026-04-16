using CinemaBooking.models;
using CinemaBooking.repositories;
using CinemaBooking.dto;

namespace CinemaBooking.services
{
    public class CinemaService
    {
        private readonly CinemaRepository _repo;

        public CinemaService(CinemaRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<CinemaDto>> GetAll()
        {
            var danhSach = await _repo.GetAllAsync();

            return danhSach.Select(r => new CinemaDto
            {
                Id = r.Id,
                Name = r.Name,
                Location = r.Location,
                Address = r.Address,
                CreatedAt = r.CreatedAt
            }).ToList();
        }

        public async Task<CinemaDto> GetById(string id)
        {
            var r = await _repo.GetByIdAsync(id);
            if (r == null) return null;

            return new CinemaDto
            {
                Id = r.Id,
                Name = r.Name,
                Location = r.Location,
                Address = r.Address,
                CreatedAt = r.CreatedAt
            };
        }

        public async Task<CinemaDto> Create(CreateCinemaDto dto)
        {
            var cinema = new Cinema
            {
                Name = dto.Name,
                Location = dto.Location,
                Address = dto.Address,
                CreatedAt = DateTime.UtcNow
            };

            await _repo.CreateAsync(cinema);

            return new CinemaDto
            {
                Id = cinema.Id,
                Name = cinema.Name,
                Location = cinema.Location,
                Address = cinema.Address,
                CreatedAt = cinema.CreatedAt
            };
        }
    }
}