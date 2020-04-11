using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.DTOs;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static Random random = new Random();
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        public UserController(IUserService userService, UserManager<IdentityUser> userManager, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._userService = userService;
            this._userManager = userManager;
        }


        // GET: api/User/5
        /// <summary>
        /// Gets a user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>200OK if User found by id along with User. 404 if no user found by id.</returns>
        [HttpGet("id/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetUser(int id)
        {
            var user = await GetCurrentUser();

            var result = _userService.GetById(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpGet("add/{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AddFriend(int id)
        {
            var user = await GetCurrentUser();
            var friendUser = _userService.GetById(id);

            //Creates a request with unique token, friendUSer will get prompted to accept the request
            UserFriendRequest friendReq = new UserFriendRequest(user, friendUser);

            var result = _userService.GetById(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpGet("requests")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetFriendRequests()
        {
            try
            {
                var user = await GetCurrentUser();
                var  result = _userService.GetFriendRequestsById(user.UserId);
                _logger.LogInformation($"Userid {user.UserId} tried to get friend requests.");
                return new OkObjectResult(result);
            }
            catch (ArgumentException e)
            {
                _logger.LogInformation(e.Message);
                return NotFound(e);
            }
        }

        [HttpGet("accept/{token}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> AcceptFriend(string token)
        {
            try
            {
                var result = _userService.AcceptFriendRequest(Guid.Parse(token));
                return new OkObjectResult(result);
            }
            catch (ArgumentException e)
            {
                _logger.LogInformation(e.Message);
                return NotFound(e);
            }
        }

        [HttpGet("id/{id}/friends")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetFriendsOfUser(int id)
        {
            var user = await GetCurrentUser();

            _logger.LogInformation($"Called by userid {user.UserId}>> GetFriendsOfUser({id}) \n Claims>> {User.Claims}");

            var result = _userService.GetFriendsByUserId(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpGet("u/{username}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult> GetByUserName(string username)
        {
            var result = await _userService.GetByUserNameAsync(username);
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
            var result = _userService.GetAll();
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        private async Task<User> GetCurrentUser()
        {
            //First get user claims    
            try
            {
                string userId = User.Claims.First(c => c.Type == "UserID").Value;
                var identityUser = await _userManager.FindByIdAsync(userId);
                var user = _userService.GetByUserName(identityUser.UserName);
                return user;
            }
            catch (ArgumentException e)
            {
                _logger.LogInformation($"Error GetCurrentUser(): {e.Message}");
            }

            return null;
        }
    }
}
