using AutoMapper;
using BusinessObject.Models;
using DataAccess.DTO;
using DataAccess.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace eBookStoreWebAPI.Controllers
{
    [Route("api/")]
    [ApiController]
    public class UserController : Controller
    {

        private readonly IUserRepository repository;
        private readonly IMapper mapper;
        private IConfiguration config;

        public UserController(IUserRepository _repository, IMapper _mapper, IConfiguration _config)
        {
            repository = _repository;
            mapper = _mapper;
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
            if (info != null)
            {
                var data = await repository.AuthenticateUser(info.Email, info.Password);
                if (data != null)
                {
                    var claims = new[]
                    {
                        new Claim(JwtRegisteredClaimNames.Sub, config["Jwt:Subject"]),
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString()),
                        new Claim("UserId", data.UserId.ToString()),
                        new Claim("Email", data.EmailAddress),
                        new Claim("Role", data.Role.RoleDesc.ToString()),
                    };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]));
                    var signin = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                            config["Jwt:Issuer"],
                            config["Jwt:Audience"],
                            claims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: signin
                        );
                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return Unauthorized();
                }
            }
            return BadRequest("Must not be left empty!");
        }

        [HttpPost("register")]
        [AllowAnonymous]
        public async Task<IActionResult> Register([FromBody] UserRegisterRequestDTO info)
        {
            if (info.Password != info.ConfirmPassword)
            {
                return Conflict("Password confirm is not matching!");
            }
            var data = await repository.GetUserByEmail(info.Email);
            if (data != null)
            {
                return Conflict("An account with the provided username already exists.");
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
