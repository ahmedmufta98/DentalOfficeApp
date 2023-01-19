using DentalOffice.Dtos;
using DentalOffice.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace DentalOffice.API.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthRepository _authRepository;
        public AuthController(IAuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        [HttpPost, Route("login")]
        public async Task<IActionResult> Login(UserLoginDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserDto loggedUser = await _authRepository.Login(request);

            if (loggedUser is not null)
            {
                return Ok(loggedUser);
            }
            return Unauthorized();
        }

        [HttpPost, Route("register")]
        public async Task<IActionResult> Register(UserDto request)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            UserDto registredUser = await _authRepository.Register(request);

            if (registredUser is not null)
            {
                return Ok(registredUser);
            }

            return BadRequest();
        }
    }
}
