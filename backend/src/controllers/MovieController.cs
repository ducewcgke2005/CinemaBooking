using CinemaBooking.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CinemaBooking.dto;

namespace CinemaBooking.controllers
{
    [Authorize(Roles = "admin")]
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
            var result = await _service.GetAll();
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var result = await _service.GetById(id);

            if (result == null)
                return NotFound();

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateMovieDto dto)
        {
            var result = await _service.Create(dto);
            return CreatedAtAction(nameof(GetById), new { id = result.Id }, result);
        }
    }
}