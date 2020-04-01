using System.ComponentModel.DataAnnotations;

namespace ZoundAPI.Models.Domain
{
    public class Artist
    {
        public int ArtistId { get; set; }
        [Required]
        public string Name { get; set; }

        public Artist()
        {
        }
    }
}
