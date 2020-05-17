using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Text.RegularExpressions;

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
        public virtual ICollection<Post> Posts { get; set; }
        // public virtual ICollection<Comment> Comments { get; set; }


        public User()
        {
            Friends = new HashSet<UserFriend>();
            FriendRequests = new HashSet<UserFriendRequest>();
            FavoriteRooms = new HashSet<FavoriteRoom>();
            // Comments = new HashSet<Comment>();
            Posts = new HashSet<Post>();
        }


        

        public User(string fName, string lName, string email, string username) : this()
        {
            if (fName.Length > 50 || lName.Length > 50)
                throw new ArgumentException("First or lastname invalid.");

            Firstname = fName;
            Lastname = lName;

            Username = username;

            var emailValid = new MailAddress(email);

            if (emailValid.Address != email)
                throw new ArgumentException("Invalid email.");

            Email = email.ToLower();
        }
        public User(string fName, string lName, string email) : this(fName, lName, email, fName + lName)
        {
            // String pattern = @"/^[a-z ,.'-]+$/i";
            // var match = Regex.Match(fName.Trim(), pattern);
            // if (!match.Success)
            //     throw new ArgumentException("First or lastname invalid.");

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

        internal void CreatePost(string title, string text)
        {
            this.Posts.Add(new Post(this, title, text));
        }
    }
}
