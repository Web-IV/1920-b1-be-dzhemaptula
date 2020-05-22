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

        private string _email;
        public string Email
        {
            get => _email;
            set
            {
                if (value.Length > 80 || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Email invalid.");

                var emailValid = new MailAddress(value);

                if (emailValid.Address != value)
                    throw new FormatException("Invalid email.");
                _email = value;
            }
        }

        private string _username;
        public string Username
        {
            get => _username;
            set
            {
                if (value.Length > 50 || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Username invalid.");
                _username = value;
            }
        }

        private string _firstName;
        public string Firstname
        {
            get => _firstName;
            set
            {
                if (value.Length > 25 || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Firstname invalid.");
                _firstName = value;
            }
        }

        private string _lastName;
        public string Lastname
        {
            get => _lastName;
            set
            {
                if (value.Length > 25 || string.IsNullOrEmpty(value))
                    throw new ArgumentException("Lastname invalid.");
                _lastName = value;
            }
        }

        public virtual ICollection<UserFriend> Friends
        {
            get;
            set;
        }

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


            Firstname = fName;
            Lastname = lName;

            Username = username;



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
