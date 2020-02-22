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
        public object File { get; set; }
        public ICollection<Artist> Artists { get; set; }
        public Song()
        {
            this.Artists = new HashSet<Artist>();
        }
        
       
    }
}
