using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IUserService
    {
        User GetById(int id);
        ICollection<User> GetAll();
        Task<User> GetByUserNameAsync(string userName);
        User GetFriendsByUserId(int id);
        void SaveChanges();
        User GetByMail(string email);
        void Add(User user);

        void Update(User user);
    }
}
