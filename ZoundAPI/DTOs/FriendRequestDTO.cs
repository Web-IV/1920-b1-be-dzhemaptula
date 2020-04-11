using System;
using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.DTOs
{
    public class FriendRequestDTO
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FriendId { get; set; }
        [Required]
        public Guid Token { get; set; }

    }
}
