using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.DTOs;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IPostService
    {
        void Add(Post post);

        Post GetById(int id);
        ICollection<Post> GetByUser(User user);

        ICollection<Post> GetAll();
        ICollection<PostDto> GetPostsByFriends(User user);
        void Delete(Post post);

    }
}
