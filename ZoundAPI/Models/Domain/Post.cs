using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; private set; }
        public ICollection<Comment> Comments { get; private set; }

        public Post(int userId, string title, string text) : this()
        {
            this.UserId = userId;
            this.Title = title;
            this.Text = text;
        }
        public Post()
        {
            Comments = new HashSet<Comment>();
        }

        public void AddComment(Comment comment)
        {
            this.Comments.Add(comment);
        }
    }
}
