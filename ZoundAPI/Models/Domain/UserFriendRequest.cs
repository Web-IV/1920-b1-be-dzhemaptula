using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZoundAPI.Models.Domain
{
    public class UserFriendRequest
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(FriendId))]
        public User Friend { get; set; }
        public int FriendId { get; set; }
        public Guid Token { get; set; }

        public UserFriendRequest(User user, User friend)
        {
            User = user;
            Friend = friend;
            //Generates a token like "65a10c6e-5fd5-4f04-8175-8601cdb5ffcd"
            Token = Guid.NewGuid();
            UserId = user.UserId;
            FriendId = friend.UserId;
        }

        public UserFriendRequest()
        {
        }
    }
}
