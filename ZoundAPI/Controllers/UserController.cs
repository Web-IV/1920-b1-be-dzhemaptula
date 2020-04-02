using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        //private readonly SignInManager<IdentityUser> signInManager;
        public UserController(IUserService userService/*, SignInManager<IdentityUser> signIn*/)
        {
            this.UserService = userService;
            //signInManager = signIn;
        }

        // GET: api/User/5
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200OK if User found by id along with User. 404 if no user found by id.</returns>
        [HttpGet("{id}", Name = "GetUserById")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult Get(int id)
        {
            var User = UserService.GetById(id);
            //return $"{User.Firstname} {User.Lastname}";
            var result = UserService.GetById(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        // POST: api/User
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/User/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
