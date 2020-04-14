using System.Collections.Generic;

namespace ZoundAPI.Models.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<UserFriend> Friends { get; set; }
        public virtual ICollection<UserFriendRequest> FriendRequests { get; set; }
        public virtual ICollection<FavoriteRoom> FavoriteRooms { get; set; }
        

        public User()
        {
            Friends = new HashSet<UserFriend>();
            FriendRequests = new HashSet<UserFriendRequest>();
            FavoriteRooms = new HashSet<FavoriteRoom>();
        }


        public User(string fName, string lName) : this()
        {
            Firstname = fName;
            Lastname = lName;
            UserName = fName + lName;
        }


        public void AddFriend(User friend)
        {
            AddFriend(new UserFriend(this,friend));
        }

        public void AddFriend(UserFriend userFriend)
        {
            Friends.Add(userFriend);
        }

        internal void AddFavoriteRoom(FavoriteRoom favoriteRoom)
        {
            FavoriteRooms.Add(favoriteRoom);
        }
    }
}
