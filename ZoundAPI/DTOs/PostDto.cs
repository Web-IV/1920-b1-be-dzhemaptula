using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.DTOs
{
    public class PostDto
    {
        public int PostId { get; set; }
        [Required] public UserDto UserDto { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Text { get; set; }
        [Required] public DateTime DatePosted { get; set; }

        public PostDto() { }
    }
}
