using System;
using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.DTOs
{
    public class UserFriendDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int FriendId { get; set; }

    }
}
