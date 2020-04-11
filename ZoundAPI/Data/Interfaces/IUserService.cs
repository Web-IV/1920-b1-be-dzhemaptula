using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        ICollection<User> GetAll();
        ICollection<UserFriendRequest> GetFriendRequestsById(int id);
        ICollection<UserFriend> GetFriendsByUserId(int id);
        Task<User> GetByUserNameAsync(string userName); 
        User GetByUserName(string userName);
        UserFriend AcceptFriendRequest(Guid token);
    }
}
