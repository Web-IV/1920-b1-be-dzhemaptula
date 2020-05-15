using System;
using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.DTOs
{
    public class FriendRequestDTO
    {
        [Required]
        public int RequestedToId { get; set; }
        [Required]
        public int RequestedFromId { get; set; }
        [Required]
        public Guid Token { get; set; }

    }
}
