using System.Collections.Generic;

namespace ZoundAPI.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public int? RoomId { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<UserFriend> Friends { get; set; }
        public virtual ICollection<UserFriendRequest> FriendRequests { get; set; }
        public virtual ICollection<FavoriteRoom> FavoriteRooms { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        

        public User()
        {
            Friends = new HashSet<UserFriend>();
            FriendRequests = new HashSet<UserFriendRequest>();
            FavoriteRooms = new HashSet<FavoriteRoom>();
            Comments = new HashSet<Comment>();
        }


        public User(string fName, string lName, string email) : this()
        {
            Firstname = fName;
            Lastname = lName;
            Username = (fName + lName).ToLower();
            Email = email.ToLower();
        }

        public User(string fName, string lName, string email, string username) : this()
        {
            Firstname = fName;
            Lastname = lName;
            Username = username;
            Email = email.ToLower();
        }

        public void AddFriend(UserFriend userFriend)
        {
            User friend = userFriend.Friend;
            Friends.Add(userFriend);
            friend.Friends.Add(new UserFriend(friend, this));
        }

        internal void AddFavoriteRoom(FavoriteRoom favoriteRoom)
        {
            FavoriteRooms.Add(favoriteRoom);
        }
    }
}
