using CinemaBooking.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase
    {
        private readonly MovieService _service;

        public MovieController(MovieService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var movies = await _service.GetAll();
            return Ok(movies);
        }

        [HttpGet("test")]
        [Authorize]
        public IActionResult Test()
        {
            return Ok("Bạn đã vào được API có authorize");
        }
    }
}