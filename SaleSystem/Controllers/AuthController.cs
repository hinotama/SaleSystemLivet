using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SaleSystemAPI.Repositories;
using SaleSystemAPI.Services.Interfaces;
using SaleSystemData.Models;

namespace SaleSystemAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IConfiguration _configuration;

        public AuthController(IAuthService authService, IConfiguration configuration)
        {
            _authService = authService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] User login)
        {
            // Check login username & password.
            User user = await _authService.CheckLogin(login.Username, login.Password);

            if (user != null)
            {
                // Randomize a new token string.
                var token = Guid.NewGuid().ToString();

                // Get expiry minutes in config file.
                int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);
                var expiration = DateTime.Now.AddMinutes(expiryInMinutes);

                // Save token to the database.
                var auth = new Auth
                {
                    Token = token,
                    Expiration = expiration,
                    UserId = user.UserId
                };
                await _authService.AddToken(auth);

                // Return the token data.
                return Ok(new
                {
                    token,
                    expiration,
                    user.UserId
                });
            }
            return Unauthorized("Username or Password is not correct.");

            //var claim = new[] {
            //    new Claim(JwtRegisteredClaimNames.Sub, user.Username)
            //};
            //var signinKey = new SymmetricSecurityKey(
            //  Encoding.UTF8.GetBytes(_configuration["Jwt:SigningKey"]));

            //int expiryInMinutes = Convert.ToInt32(_configuration["Jwt:ExpiryInMinutes"]);
            //var expiration = DateTime.UtcNow.AddMinutes(expiryInMinutes);

            //var token = new JwtSecurityToken(
            //  issuer: _configuration["Jwt:Site"],
            //  audience: _configuration["Jwt:Site"],
            //  expires: expiration,
            //  signingCredentials: new SigningCredentials(signinKey, SecurityAlgorithms.HmacSha256)
            //);

            //var userToken = new UserTokens
            //{
            //    Token = new JwtSecurityTokenHandler().WriteToken(token),
            //    Expiration = DateTime.UtcNow.AddMinutes(expiryInMinutes)
            //};
            //await _commonRepository.AddUserToken(userToken);

            //return Ok(
            //  new
            //  {
            //      token = new JwtSecurityTokenHandler().WriteToken(token),
            //      expiration = token.ValidTo
            //  });
        }
    }
}