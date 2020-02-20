using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Interfaces;

namespace ZoundAPI.Models.Domain
{
    public class User : IdentityUser
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Username { get; set; }

        public User()
        {

        }

        public User(RegisterDTO dto)
        {
            this.UserName = dto.Email;
            this.Email = dto.Email;
            this.Firstname = dto.FirstName;
            this.Lastname = dto.LastName;
            this.Username = Username;
        }

        
    }
}
