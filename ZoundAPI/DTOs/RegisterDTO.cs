using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.Models.Domain
{
    public class RegisterDTO
    {
        public string Email { get; internal set; }
        public string FirstName { get; internal set; }
        public string LastName { get; internal set; }
        [Required]
        [Compare("Password")]
        [RegularExpression("^.*(?=.{6,10})(?=.*[a-zA-Z].*[a-zA-Z].*[a-zA-Z].*[a-zA-Z]).*$", 
            ErrorMessage = "Password must contain 6 to 10 characters. At least 4 letters and 2 numbers.")]
        public string PasswordConfirmation { get; set; }
    }
}