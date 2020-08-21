using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using MyAppWithAngular.Data.Authentication;
using MyAppWithAngular.DTO.Authentication;
using MyAppWithAngular.Models.Users;

namespace MyAppWithAngular.Controllers
{
    [ApiController, Route("api/[controller]")]
    public class AuthenticationController : ControllerBase
    {
        private IAuthenticationRepository _authenticationRepository;
        private readonly IConfiguration _configuration;

        public AuthenticationController(IAuthenticationRepository authenticationRepository, IConfiguration configuration)
        {
            this._authenticationRepository = authenticationRepository;
            this._configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationRequest request)
        {
            string userName = request.UserName.ToLower();

            if (await _authenticationRepository.UserExists(userName))
                return BadRequest("Username already exists");

            User user = await _authenticationRepository.RegisterNewUser(userName, request.Password);

            RegistrationResponse response = new RegistrationResponse()
            {
                UserID = user.Id,
                UserName = user.UserName
            };

            return StatusCode(StatusCodes.Status201Created, response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login (LoginRequest request)
        {
            User dbUser = await _authenticationRepository.Login(request.UserName.ToLower(), request.Password);

            if (dbUser == null) return Unauthorized();

            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, dbUser.Id.ToString()),
                new Claim(ClaimTypes.Name, dbUser.UserName)
            };

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetSection("AppSetting:Token").Value));

            SigningCredentials credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddDays(3),
                SigningCredentials = credentials
            };

            JwtSecurityTokenHandler jwtSecurityTokenHandler = new JwtSecurityTokenHandler();

            SecurityToken securityToken = jwtSecurityTokenHandler.CreateToken(tokenDescriptor);

            return Ok(new LoginResponse() { AuthenticationToken = jwtSecurityTokenHandler.WriteToken(securityToken) });
        }
    }
}
