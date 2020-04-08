using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ZoundAPI.Data.Interfaces;

namespace ZoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService UserService;
        public UserController(IUserService userService/*, SignInManager<IdentityUser> signIn*/)
        {
            this.UserService = userService;
        }

        // GET: api/User/5
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200OK if User found by id along with User. 404 if no user found by id.</returns>
        [AllowAnonymous]
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetUser(int id)
        {
            var result = UserService.GetById(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("id/{id}/Friends")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult GetFriendsOfUser(int id)
        {
            var result = UserService.GetFriendsByUserId(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [AllowAnonymous]
        [HttpGet("u/{username}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetByUserName(string username)
        {
            var result = await UserService.GetByUserNameAsync(username);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpGet("/all")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetAllUsers()
        {
            var result = UserService.GetAll();
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        // [HttpGet("{id}", Name = "GetUserById")]
        // [ProducesResponseType(StatusCodes.Status404NotFound)]
        // [ProducesResponseType(StatusCodes.Status200OK)]
        // public ActionResult Get(int id)
        // {
        //     var User = UserService.GetById(id);
        //     //return $"{User.Firstname} {User.Lastname}";
        //     var result = UserService.GetById(id);
        //     if (result != null)
        //         return new OkObjectResult(result);
        //     return NotFound();
        // }

        // // POST: api/User
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }
        //
        // // PUT: api/User/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/ApiWithActions/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
    
    }
}
