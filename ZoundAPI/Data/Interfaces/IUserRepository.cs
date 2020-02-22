using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IUserRepository
    {
        User GetById(int id);
        void SaveChanges();
        User GetByMail(string mail);
        void Add(User user);
    }
}
