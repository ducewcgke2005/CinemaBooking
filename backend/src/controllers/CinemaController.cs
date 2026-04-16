using CinemaBooking.services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace CinemaBooking.controllers
{
    [Authorize(Roles = "admin")]
    [ApiController]
    [Route("api/[controller]")]
    public class CinemaController : ControllerBase
    {
        private readonly CinemaService _service;

        public CinemaController(CinemaService service)
        {
            _service = service;
        }

        [AllowAnonymous]
        [HttpGet("list")]
        public async Task<IActionResult> Get()
        {
            var cinemas = await _service.GetAll();
            return Ok(cinemas);
        }

        [AllowAnonymous]
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var cinema = await _service.GetById(id);
            if (cinema == null)
                return NotFound();

            return Ok(cinema);
        } 
    }
}