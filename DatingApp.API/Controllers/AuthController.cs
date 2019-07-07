using Microsoft.AspNetCore.Mvc;

namespace DatingApp.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IauthRepository _repo;
        public AuthController (IauthRepository repo)
        {
            _repo = repo;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(UserForRegisterDto)
        {
            // validate request

            username = username.ToLower();

            if (await _repo.UserExists(username))
                return BadRequest("Username already exists");
            
            var userToCreate = new User
            {
                Username = username
            };

            var createdUser = await _repo.Register(userToCreate, password);

            return StatusCode(201);
        }
    }
}