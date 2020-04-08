using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Primitives;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class UserService : IUserService
    {
        private readonly ZoundContext _context;
        private readonly DbSet<User> _users;

        public UserService(ZoundContext context)
        {
            this._context = context;
            this._users = context.Users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }
        public async Task<User> GetByUserNameAsync(string userName)
        {
            return await _users.FirstOrDefaultAsync(x => x.UserName.Equals(userName));
        }

        public ICollection<User> GetAll()
        {
            return this._users.ToList();
        }

        public User GetById(int id)
        {

            return _users.FirstOrDefault(b => b.UserId.Equals(id));
        }

        public User GetFriendsByUserId(int id)
        {
            return _users.Include(x => x.Friends).ToList().FirstOrDefault(b => b.UserId.Equals(id));
        }

        public User GetByMail(string email)
        {
            return _users.FirstOrDefault(b => b.Email.Equals(email));
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }

        public void Update(User user)
        {
            this._users.Update(user);
        }

        
    }
}
