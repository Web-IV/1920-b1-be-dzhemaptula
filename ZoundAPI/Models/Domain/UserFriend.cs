using System.ComponentModel.DataAnnotations.Schema;

namespace ZoundAPI.Models.Domain
{
    public sealed class UserFriend
    {
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public int UserId { get; set; }

        [ForeignKey(nameof(FriendId))]
        public User Friend { get; set; }
        public int FriendId { get; set; }

        public UserFriend(User user, User friend)
        {
            User = user;
            Friend = friend;
            UserId = user.UserId;
            FriendId = friend.UserId;
        }

        public UserFriend()
        {
        }
    }
}
