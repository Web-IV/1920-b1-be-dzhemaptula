using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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


    }
}
