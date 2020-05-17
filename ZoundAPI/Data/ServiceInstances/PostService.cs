using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.ServiceInstances
{
    public class PostService : IPostService
    {
        private readonly ZoundContext _context;
        private readonly ILogger _logger;
        private readonly DbSet<Post> _posts;

        public PostService(ZoundContext context, ILogger<UserService> _logger)
        {
            this._context = context;
            this._logger = _logger;
            this._posts = context.Posts;
        }


        public void Add(Post post)
        {
            _posts.Add(post);
            _context.SaveChanges();
        }

        public void Delete(Post post)
        {
            _posts.Remove(post);
            _context.SaveChanges();
        }

        public ICollection<Post> GetAll()
        {
            return _posts
                .Select(x => new Post
                    {
                        UserId = x.UserId,
                        Title = x.Title,
                        Text = x.Text,
                        DatePosted = x.DatePosted
                    }
                ).ToList();
        }

        public Post GetById(int id)
        {
            return _posts.Select(x => new Post
                {
                    UserId = x.UserId,
                    Title = x.Title,
                    Text = x.Text,
                    DatePosted = x.DatePosted
                }
            ).FirstOrDefault(x => x.PostId.Equals(id));
        }

        public ICollection<Post> GetByUser(User user)
        {
            return _posts.Where(x => x.UserId.Equals(user.UserId))
                .Select(x => new Post
                    {
                        UserId = x.UserId,
                        User = new User
                        {
                            Username = user.Username,
                            Firstname = user.Firstname,
                            Lastname = user.Lastname
                        },
                        Title = x.Title,
                        Text = x.Text,
                        DatePosted = x.DatePosted
                    }

                )
                .OrderBy(x => x.DatePosted)
                .Take(100)
                .ToList();

        }

        public ICollection<Post> GetPostsByFriends(User user)
        {

            return user.Friends
                .Select(x => x.Friend.Posts
                    .Select(x => new Post
                                {
                                    UserId = x.UserId,
                                    User = new User
                                    {
                                        Username = user.Username,
                                        Firstname = user.Firstname,
                                        Lastname = user.Lastname
                                    },
                                    Title = x.Title,
                                    Text = x.Text,
                                    DatePosted = x.DatePosted
                                }
                    )
                    .OrderBy(x => x.DatePosted)
                    .Take(200)
                    .ToList()
                ).FirstOrDefault() 
                   ?? throw new ArgumentException("Something went wrong at getting posts from friends");


            //slow? rewriting

            // return _posts.Select(x => new Post
            //     {
            //         UserId = x.UserId,
            //         User = new User
            //         {
            //             Username = user.Username,
            //             Firstname = user.Firstname,
            //             Lastname = user.Lastname
            //         },
            //         Title = x.Title,
            //         Text = x.Text,
            //         DatePosted = x.DatePosted
            //     }).Where(post => user.Friends
            //         // .Select(friend => friend.FriendId)
            //         // .ToList()
            //         // .Contains(post.UserId))
            //         .Any(x => x.FriendId.Equals(post.UserId)))
            //     .ToList()
            //     .OrderBy(x => x.DatePosted)
            //     .Take(100)
            //     .ToList();

            //wrong

            //     return _context.Users
            //         .Where(x => x.UserId.Equals(user.UserId))
            //         .Select(x => x.Posts.Select(x => new Post
            //             {
            //                 UserId = x.UserId,
            //                 User = new User
            //                 {
            //                     Username = user.Username,
            //                     Firstname = user.Firstname,
            //                     Lastname = user.Lastname
            //                 },
            //                 Title = x.Title,
            //                 Text = x.Text,
            //                 DatePosted = x.DatePosted
            //             }
            //         ).ToList())
            //         .FirstOrDefault();
            //
            // }
        }
    }
}
