using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class FeaturedArtist
    {
        [ForeignKey(nameof(ArtistId))] 
        public Artist Artist { get; set; }
        public int ArtistId { get; set; }

        [ForeignKey(nameof(SongId))]
        public Song Song { get; set; }
        public int SongId { get; set; }
    }
}
