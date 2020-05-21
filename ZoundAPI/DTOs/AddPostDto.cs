using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.DTOs
{
    public class AddPostDto
    {
        [Required] public int UserId { get; set; }
        [Required] public string Title { get; set; }
        [Required] public string Text { get; set; }
        [Required] public DateTime DatePosted { get; set; }

        public AddPostDto() { }
    }
}
