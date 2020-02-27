using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ZoundContext context;

        public UserRepository(ZoundContext context)
        {
            this.context = context;
        }

        public void Add(User user)
        {
            this.context.Users.Add(user);
        }

        public User GetById(string id)
        {
            return context.Users.FirstOrDefault(b => b.Id.Equals(id));
        }

        public User GetByMail(string email)
        {
            return context.Users.FirstOrDefault(b => b.Email.Equals(email));
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
