using System.ComponentModel.DataAnnotations;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.DTOs
{
    public class UserDto
    {
        /* "userId": 2,
        "email": null,
        "userName": "nicklersberghe",
        "firstname": "Nick",
        "lastname": "Lersberghe",
         */
        [Required] public int UserId { get; set; }
        [Required] public string Email { get; set; }
        [Required] public string UserName { get; set; }
        [Required] public string FirstName { get; set; }
        [Required] public string LastName { get; set; }

        public UserDto(int userId, string email, string userName, string firstName, string lastName)
        {
            UserId = userId;
            Email = email;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
        }
        public UserDto() { }
    }
}