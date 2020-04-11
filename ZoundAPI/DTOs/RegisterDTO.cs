﻿using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.DTOs
{
    public class RegisterDto
    {
        
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string PasswordConfirmation { get; set; }
    }
}
