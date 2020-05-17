using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IPostService
    {
        void Add(Post post);

        Post GetById(int id);
        ICollection<Post> GetByUser(User user);

        ICollection<Post> GetAll();
        ICollection<Post> GetPostsByFriends(User user);
        void Delete(Post post);

    }
}
