using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.DTOs
{
    public class LoginDto
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
