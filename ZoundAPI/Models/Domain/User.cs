using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace ZoundAPI.Models.Domain
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public virtual ICollection<UserFriend> Friends { get; set; }
        public virtual ICollection<FavoriteRoom> FavoriteRooms { get; set; }

        public User()
        {
            
        }

        public User(RegisterDTO dto)
        {
            this.Firstname = dto.FirstName;
            this.Lastname = dto.LastName;
        }


        public void AddFriend(User friend)
        {
            AddFriend(new UserFriend(this, friend));
        }

        public void AddFriend(UserFriend userFriend)
        {
            Friends.Add(userFriend);
        }
    }
}
