using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Nancy;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Data.ServiceInstances;
using ZoundAPI.DTOs;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class UserService : IUserService
    {
        private readonly ZoundContext _context;
        private readonly ILogger _logger;
        private readonly DbSet<User> _users;

        public UserService(ZoundContext context, ILogger<UserService> _logger)
        {
            this._context = context;
            this._logger = _logger;
            this._users = context.Users;
        }

        public void Add(User user)
        {
            _users.Add(user);

            _context.SaveChanges();
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _users.FirstOrDefaultAsync(x => x.Username.Equals(userName));
        }

        public User GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.Username.Equals(userName)) ?? throw new ArgumentException("Something went wrong finding user.");
        }

        public ICollection<User> GetAll()
        {
            return this._users.ToList();
        }

        public User GetById(int id)
        {
            return _users.FirstOrDefault(b => b.UserId.Equals(id));
        }

        public ICollection<UserDto> GetFriendsByUserId(int id)
        {
            //First get a list of friend ids

            //return _users.Include(x => x.Friends).ToList().FirstOrDefault(b => b.RequestedToID.Equals(id));
            var ids = _users.Include(x => x.Friends)
                       .FirstOrDefault(x => x.UserId.Equals(id))
                       ?.Friends.Select(x => x.FriendId).ToList()
                   ?? throw new ArgumentException("Something went wrong at requests.");
            ICollection<UserDto> result = new HashSet<UserDto>();

            // return _users.Where(us => ids.Contains(us.RequestedToID)).GroupBy(x => new
            // {
            //     x.RequestedToID, x.Email, x.UserName, x.Firstname, x.Lastname
            // }).ToList();

            _users.Where(u => ids.Contains(u.UserId)).ToList().ForEach(x =>
            {
                //add all the friends to a filtered clean DTO to send to request
                result.Add(new FilterUserService().ConvertToDto(x));
            });

            /*new UserDto(
                
            RequestedToID = x.RequestedToID,
            Email = x.Email,
            FirstName = x.Firstname,
            LastName = x.Lastname, 
            UserName = x.UserName
            */

            return result;
        }

        public User GetByMail(string email)
        {
            return _users.FirstOrDefault(b => b.Email.Equals(email));
        }

        public UserFriend AcceptFriendRequest(Guid token)
        {
            var friendReq = _context.UserFriendRequests.FirstOrDefault(x => x.Token.Equals(token));
            //if friendreq was not found with token, throw error
            if (friendReq == null)
                throw new ArgumentException("RequestedFrom request not found.");

            var user = _users.FirstOrDefault(x => x.UserId.Equals(friendReq.RequestedToID));
            var friend = _users.FirstOrDefault(x => x.UserId.Equals(friendReq.RequestedFromID));

            //if user or friend wasn't found in db, friend req deleted
            if (user == null || friend == null)
            {
                _context.UserFriendRequests.Remove(friendReq);
                throw new ArgumentException("ReuqestedTo or friend not found.");
            }

            //create new user friend
            var userFriend = new UserFriend(user, friend);

            //add it to user class
            user.AddFriend(userFriend);

            //update the context
            _users.Update(user);
            _context.SaveChanges();

            //check if the friendreq is successfully saved in the db, if so, delete the friendreq row
            if (_context.UserFriends.FirstOrDefault(x => x.Equals(userFriend)) == null)
            {
                _logger.LogInformation($"Error in AcceptFriendRequest <UserService> >>> ReuqestedTo: {user.Username}, friend: {friend.Username}");
                throw new ArgumentException("Something went wrong in accepting friend request.");
            }
            _context.UserFriendRequests.Remove(friendReq);
            _context.SaveChanges();
            return userFriend;
        }

        public UserFriendRequest SendFriendRequest(User requestedTo, User requestedFrom)
        {
            UserFriendRequest friendReq = new UserFriendRequest(requestedTo, requestedFrom);

            try
            {
                requestedTo.FriendRequests.Add(friendReq);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Error in SendFriendRequest <UserService> >>> {e.Message}");
                throw new ArgumentException("Something went wrong sending friend request.");
            }
            _context.UserFriendRequests.Add(friendReq);
            _context.SaveChanges();
            return friendReq;
        }

        public ICollection<UserFriendRequest> GetFriendRequestsById(int id)
        {
            return _users
                       .Include(x => x.FriendRequests)
                       .ThenInclude(x => x.RequestedFrom)
                .FirstOrDefault(x => x.UserId.Equals(id))
                ?.FriendRequests
                   ?? throw new ArgumentException("Something went wrong at retrieving requests.");
        }
    }
}
