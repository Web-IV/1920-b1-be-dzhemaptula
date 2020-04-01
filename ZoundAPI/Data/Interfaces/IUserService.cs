using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IUserService
    {
        User GetById(string id);
        void SaveChanges();
        User GetByMail(string email);
        void Add(User user);

        void Update(User user);
    }
}
