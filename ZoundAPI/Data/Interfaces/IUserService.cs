using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZoundAPI.DTOs;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        User GetById(int id);
        ICollection<User> GetAll();
        ICollection<UserFriendRequest> GetFriendRequestsById(int id);
        ICollection<UserFriendRequest> GetSentFriendrequestsById(int id);
        ICollection<UserDto> GetFriendsByUserId(int id);
        Task<User> GetByUserNameAsync(string username); 
        User GetByUserName(string username);
        bool UsernameAvailable(string username);
        UserFriend AcceptFriendRequest(Guid token);
        UserFriendRequest SendFriendRequest(User user, User friend);
        UserFriendRequest DeleteFriendRequest(Guid token);
    }
}
