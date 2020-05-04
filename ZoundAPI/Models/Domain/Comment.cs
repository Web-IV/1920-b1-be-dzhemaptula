using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class Comment
    {
        public int CommentId { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public int Likes { get; set; }
    }
}
