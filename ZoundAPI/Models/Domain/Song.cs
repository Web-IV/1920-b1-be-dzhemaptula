using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class Song
    { 
        public int SongId { get; set; }
        public string Name { get; set; }
        public string METADATA { get; set; }
        public Artist Artist { get; set; }
        public virtual ICollection<FeaturedArtist> FeaturedArtists { get; set; }

        public Song()
        {
        }
        
       
    }
}
