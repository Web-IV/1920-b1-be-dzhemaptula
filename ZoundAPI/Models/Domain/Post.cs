using System;
using System.Collections.Generic;

namespace ZoundAPI.Models.Domain
{
    public class Post
    {
        public int PostId { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public int Likes { get; private set; }
        public DateTime DatePosted { get; set; }
        // public ICollection<Comment> Comments { get; private set; }

        public Post(User user, string title, string text) : this()
        {
            this.UserId = user.UserId;
            this.User = user;
            this.Title = title;
            this.Text = text;
        }
        public Post()
        {
            this.DatePosted = DateTime.Now;
            this.Likes = 0;
            // this.Comments = new HashSet<Comment>();
        }

        // public void AddComment(Comment comment)
        // {
        //     this.Comments.Add(comment);
        // }

        // public void LikePost(/*TODO: Create a list of user id's that liked the post */)
        // {
        //     this.Likes += 1;
        // }
    }
}
