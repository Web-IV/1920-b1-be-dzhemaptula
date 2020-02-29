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
    public class UserRepository : IUserRepository
    {
        private readonly ZoundContext _context;
        private readonly DbSet<User> _users;

        public UserRepository(ZoundContext context)
        {
            this._context = context;
            this._users = context.Users;
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User GetById(string id)
        {
            return _users.FirstOrDefault(b => b.Id.Equals(id));
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
