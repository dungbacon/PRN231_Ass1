using BusinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories;
using eBookStoreWebAPI.Configs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository repository;
        private IConfiguration config;

        public UserController(IUserRepository _repository, IConfiguration _config)
        {
            repository = _repository;
            config = _config;
        }

        [HttpGet("users")]
        [Authorize]
        public async Task<IActionResult> GetUsers()
        {
            var data = await repository.GetUsers();
            return Ok(data);
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> AuthenticateUser([FromBody] UserRequestDTO info)
        {
            if (info == null) return BadRequest();

            var data = await repository.AuthenticateUser(info.Email, info.Password);

            if (data == null) return Unauthorized();

            var accessToken = JwtConfig.CreateToken(data, config);

            var response = new UserResponseDTO
            {
                Email = data.EmailAddress,
                AccessToken = accessToken
            };

            return Ok(response);
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO info)
        {
            if (info.Password != info.ConfirmPassword)
            {
                return BadRequest();
            }
            var data = await repository.GetUserByEmail(info.Email);
            if (data != null)
            {
                return BadRequest();
            }
            else
            {
                var user = new User
                {
                    EmailAddress = info.Email,
                    Password = info.Password,
                    Source = "",
                    FirstName = "",
                    MiddleName = "",
                    LastName = "",
                    RoleId = 2,
                    PubId = 1,
                    HireDate = DateTime.Now,
                };
                await repository.SaveUser(user);
                return Ok();
            }
        }
    }
}
