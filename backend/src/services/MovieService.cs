using CinemaBooking.models;
using CinemaBooking.repositories;
using CinemaBooking.dto;

namespace CinemaBooking.services
{
    public class MovieService
    {
        private readonly MovieRepository _repo;

        public MovieService(MovieRepository repo)
        {
            _repo = repo;
        }

        public async Task<List<MovieDto>> GetAll()
        {
            var movies = await _repo.GetAllAsync();

            return movies.Select(m => new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Duration = m.Duration,
                Genre = m.Genre,
                Poster = m.Poster,
                ReleaseDate = m.ReleaseDate,
                Status = m.Status
            }).ToList();
        }

        public async Task<MovieDto> GetById(string id)
        {
            var m = await _repo.GetByIdAsync(id);

            if (m == null) return null;

            return new MovieDto
            {
                Id = m.Id,
                Title = m.Title,
                Duration = m.Duration,
                Genre = m.Genre,
                Poster = m.Poster,
                ReleaseDate = m.ReleaseDate,
                Status = m.Status
            };
        }

        public async Task<MovieDto> Create(CreateMovieDto dto)
        {
            var movie = new Movie
            {
                Title = dto.Title,
                Description = dto.Description,
                Duration = dto.Duration,
                Genre = dto.Genre,
                Poster = dto.Poster,
                Trailer = dto.Trailer,
                ReleaseDate = dto.ReleaseDate,
                Status = "coming",
                CreatedAt = DateTime.UtcNow
            };

            await _repo.CreateAsync(movie);

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Poster = movie.Poster,
                ReleaseDate = movie.ReleaseDate,
                Status = movie.Status
            };
        }

        public async Task<MovieDto> UpdateStatus(string id, UpdateMovieStatusDto dto)
        {
            var movie = await _repo.GetByIdAsync(id);
            if (movie == null) return null;

            var updated = await _repo.UpdateStatusAsync(id, dto.Status);
            if (!updated) return null;

            movie.Status = dto.Status;

            return new MovieDto
            {
                Id = movie.Id,
                Title = movie.Title,
                Duration = movie.Duration,
                Genre = movie.Genre,
                Poster = movie.Poster,
                ReleaseDate = movie.ReleaseDate,
                Status = movie.Status
            };
        }
    }
}