using Microsoft.AspNetCore.Mvc;
using CinemaBooking.services;
using CinemaBooking.dtos;

namespace CinemaBooking.controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AuthService _authService;
        private readonly JwtService _jwtService;

        public AuthController(AuthService authService, JwtService jwtService)
        {
            _authService = authService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest req)
        {
            var user = await _authService.Login(req.UserName, req.Password);

            if (user == null)
                return Unauthorized("Sai tài khoản hoặc mật khẩu");

            var token = _jwtService.GenerateToken(user);

            return Ok(new
            {
                token,
                role = user.Role,
                userName = user.UserName
            });
        }
    }
}