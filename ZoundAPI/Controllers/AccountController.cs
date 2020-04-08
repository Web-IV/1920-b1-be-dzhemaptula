using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models;
using ZoundAPI.Models.Domain;
using ZoundAPI.Models.ViewModels;

namespace ZoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly UserManager<IdentityUser> UserManager;
        private readonly SignInManager<IdentityUser> SignInManger;
        public AccountController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            UserManager = userManager;
            SignInManger = signInManager;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        //POST : /api/Account/Register
        public async Task<IActionResult> Register(RegisterDTO model)
        {
            var user = new IdentityUser { UserName = model.UserName, Email = model.Email };
            var result = await UserManager.CreateAsync(user, model.PasswordConfirmation);
            if (result.Succeeded)
            {
                await SignInManger.SignInAsync(user, isPersistent: true);
                return Ok();
            }
            return BadRequest(model);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("Login")]
        //POST : /api/Account/Login
        public async Task<IActionResult> Login(LoginDTO model)
        {
            var user = await UserManager.FindByNameAsync(model.UserName);
            if (user != null && await UserManager.CheckPasswordAsync(user, model.Password))
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
