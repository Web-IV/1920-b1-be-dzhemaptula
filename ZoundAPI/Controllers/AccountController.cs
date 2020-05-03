using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Nancy.Json;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Data.Repositories;
using ZoundAPI.DTOs;
using ZoundAPI.Models;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserService _userService;
        private readonly ILogger<AccountController> _logger;

        public AccountController(UserManager<IdentityUser> userManager, IUserService _userService, ILogger<AccountController> _logger)
        {
            this._userManager = userManager;
            this._userService = _userService;
            this._logger = _logger;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        //POST : /api/Account/Register
        public async Task<IActionResult> Register(RegisterDto model)
        {
            if (model.Password == model.PasswordConfirmation)
            {
                var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    User newUser = new User(model.FirstName,model.LastName);
                    _userService.Add(newUser);
                    return Ok();
                }
            }
            return BadRequest(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        //POST : /api/Account/Login
        public async Task<IActionResult> Login(LoginDto model)
        {
            var json = new JavaScriptSerializer().Serialize(model);
           //_logger.LogInformation($"Call to /api/account/login with body {json}");

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
            {
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim("UserID", user.Id),
                    }),
                    Expires = DateTime.UtcNow.AddMinutes(5),
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("SignInKey"))),
                        SecurityAlgorithms.HmacSha256Signature)
                };
                var tokenHandler = new JwtSecurityTokenHandler();
                var securityToken = tokenHandler.CreateToken(tokenDescriptor);
                var token = tokenHandler.WriteToken(securityToken);
                return Ok(new { token });
            }
            return BadRequest(new { message = "Username or password is incorrect." });

        }
    }
}
