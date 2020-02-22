using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class User : IdentityUser
    {
        public int UserId { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public ICollection<User> Friends { get; set; }

        public User()
        {
            Friends = new HashSet<User>();
        }

        public User(RegisterDTO dto)
        {
            this.UserName = dto.Email;
            this.Email = dto.Email;
            this.Firstname = dto.FirstName;
            this.Lastname = dto.LastName;
        }

        
    }
    public class UserFriend
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
    }
}
