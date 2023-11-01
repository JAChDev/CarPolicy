using CarPolicy.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CarPolicy.WebApi.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController:ControllerBase
    {
        private readonly IJwtService _jwtService;

        public AuthController(IJwtService jwtService)
        {
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        public IActionResult Login()
        {
            // Se emula un sistema de autenticación, generando token al consumir
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, "user"), 
            };

            var token = _jwtService.GenerateToken(new ClaimsIdentity(claims, "jwt"));

            return Ok(new { token });
        }
    }
}
