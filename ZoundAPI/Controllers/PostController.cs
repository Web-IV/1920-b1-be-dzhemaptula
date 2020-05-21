using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/posts")]
    [Authorize]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IUserService _userService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IPostService _postService;
        public PostController(IUserService userService, UserManager<IdentityUser> userManager, ILogger<UserController> logger, IPostService postService)
        {
            this._logger = logger;
            this._userService = userService;
            this._userManager = userManager;
            this._postService = postService;
        }

        [HttpPost("add")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> AddPost(AddPostDto model)
        {
            User currentUser = await GetCurrentUser();
            if (model.UserId != currentUser.UserId)
                return BadRequest(new {message = "Authentication issue, please re-log."});

            Post post = new Post(_userService.GetById(model.UserId), model.Title, model.Text);

            try
            {
                _postService.Add(post);

            }
            catch (Exception e)
            {
                return BadRequest(new {message = "Error in adding post: " + e.Message});
            }

            PostDto postDto = new PostDto
            {
                UserDto = new UserDto(currentUser.UserId, currentUser.Email, currentUser.Username, currentUser.Firstname,
                    currentUser.Lastname),
                DatePosted = post.DatePosted,
                PostId = post.PostId, Text = post.Text, Title = post.Title
            };
            return Ok(postDto);
        }

        [HttpGet("friends")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetPostsFromFriends()
        {
            var currentUser = await GetCurrentUser();

            //_logger.LogInformation($"Called by userid {user.UserId}>> GetFriendsOfUser({id}) \n Claims>> {User.Claims}");

            var result = _postService.GetPostsByFriends(currentUser);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpGet("all")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> GetAllPosts()
        {
            //_logger.LogInformation($"Called by userid {user.UserId}>> GetFriendsOfUser({id}) \n Claims>> {User.Claims}");

            var result = _postService.GetAll();
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
        }

        [HttpDelete("{id}/delete")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public async Task<ActionResult> DeletePost(int id)
        {
            //_logger.LogInformation($"Called by userid {user.UserId}>> GetFriendsOfUser({id}) \n Claims>> {User.Claims}");

            var result = _postService.GetById(id);
            if (result != null)
            {
                try
                {
                    _postService.Delete(result);
                    return Ok();
                }
                catch (Exception e)
                {
                    return BadRequest();
                }
            }
            return NotFound();
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetByPostId(int id)
        {
            //_logger.LogInformation($"Called by userid {user.UserId}>> GetFriendsOfUser({id}) \n Claims>> {User.Claims}");

            var result = _postService.GetById(id);
            if (result != null)
                return new OkObjectResult(result);
            return NotFound();
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
                var user = _userService.GetByUserNameIncludeFriends(identityUser.UserName);
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
