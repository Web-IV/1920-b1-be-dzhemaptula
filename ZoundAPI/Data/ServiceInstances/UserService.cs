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
            return await _users.FirstOrDefaultAsync(x => x.UserName.Equals(userName));
        }

        public User GetByUserName(string userName)
        {
            return _users.FirstOrDefault(x => x.UserName.Equals(userName)) ?? throw new ArgumentException("Something went wrong finding user.");
        }

        public ICollection<User> GetAll()
        {
            return this._users.ToList();
        }

        public User GetById(int id)
        {

            return _users.FirstOrDefault(b => b.UserId.Equals(id));
        }

        public ICollection<UserFriend> GetFriendsByUserId(int id)
        {
            //return _users.Include(x => x.Friends).ToList().FirstOrDefault(b => b.UserId.Equals(id));
            return _users.Include(x => x.Friends)
                       .FirstOrDefault(x => x.UserId.Equals(id))
                       ?.Friends
                   ?? throw new ArgumentException("Something went wrong at requests.");

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
                throw new ArgumentException("Friend request not found.");

            var user = _users.FirstOrDefault(x => x.UserId.Equals(friendReq.UserId));
            var friend = _users.FirstOrDefault(x => x.UserId.Equals(friendReq.FriendId));

            //if user or friend wasn't found in db, friend req deleted
            if (user == null || friend == null)
            {
                _context.UserFriendRequests.Remove(friendReq);
                throw new ArgumentException("User or friend not found.");
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
                _logger.LogInformation($"Error UserService>> User: {user.UserName}, friend: {friend.UserName}");
                throw new ArgumentException("Something went wrong in accepting friend request.");
            }
            _context.UserFriendRequests.Remove(friendReq);
            _context.SaveChanges();
            return userFriend;
        }

        public ICollection<UserFriendRequest> GetFriendRequestsById(int id)
        {
            return _users.Include(x => x.FriendRequests)
                .FirstOrDefault(x => x.UserId.Equals(id))
                ?.FriendRequests 
                   ?? throw new ArgumentException("Something went wrong at requests.");
        }
    }
}
