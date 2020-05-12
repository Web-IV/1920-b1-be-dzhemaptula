using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class FriendController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        public FriendController(IUserService userService, UserManager<IdentityUser> userManager, ILogger<UserController> logger)
        {
            this._logger = logger;
            this._userService = userService;
            this._userManager = userManager;
        }


        [HttpGet("accept/{token}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
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

        [HttpDelete("decline/{token}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeclineFriend(string token)
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

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddFriend(UserDto model)
        {
            if (model == null)
            {
                throw new ArgumentNullException("Post data of add friend is null.");
            }

            var requestedFrom = await GetCurrentUser();
            var requestedTo = _userService.GetById(model.UserId);
            if (requestedTo.Username != model.Username)
            {
                throw new ArgumentException("Post data of add friend is invalid.");
            }

            //Creates a request with unique token, friendUSer will get prompted to accept the request
            //UserFriendRequest friendReq = new UserFriendRequest(user, friendUser);

            var result = _userService.SendFriendRequest(requestedTo, requestedFrom);

            if (result != null)
                return Ok(new {result});
            return NotFound();
        }

        [HttpGet("requests/received")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetFriendRequests()
        {
            try
            {
                var user = await GetCurrentUser();
                var result = _userService.GetFriendRequestsById(user.UserId);
                //_logger.LogInformation($"Userid {user.UserId} tried to get friend requests.");
                return new OkObjectResult(result);
            }
            catch (ArgumentException e)
            {
                _logger.LogInformation(e.Message);
                return NotFound(e);
            }
        }

        [HttpGet("requests/sent")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetSentFriendRequests()
        {
            try
            {
                var user = await GetCurrentUser();
                var result = _userService.GetFriendRequestsById(user.UserId);
                //_logger.LogInformation($"Userid {user.UserId} tried to get friend requests.");
                return new OkObjectResult(result);
            }
            catch (ArgumentException e)
            {
                _logger.LogInformation(e.Message);
                return NotFound(e);
            }
        }

        private async Task<User> GetCurrentUser()
        {
            try
            {
                //get identity userid from claims
                string userId = User.Claims.First(c => c.Type == "UserID").Value;

                //get identity class
                var identityUser = await _userManager.FindByIdAsync(userId);

                //get user class by identity username
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
