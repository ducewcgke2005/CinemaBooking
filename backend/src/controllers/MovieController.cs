using CinemaBooking.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.controllers
{
    [Authorize(Roles="admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var movies = await _service.GetAll();
            return Ok(movies);
        }

        [HttpGet("test")]
        public IActionResult Test()
        {
            return Ok("Bạn đã vào được API có authorize");
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var movie = await _service.GetById(id);
            if (movie == null)
                return NotFound();

            return Ok(movie);
        }

    }
}