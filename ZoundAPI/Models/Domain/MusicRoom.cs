using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Interfaces;

namespace ZoundAPI.Models.Domain
{
    public class MusicRoom : IMusicRoom
    {
        public string Name { get; set; }
        public string Genre { get; private set; }
        public string Description { get; set; }
        public ICollection<User> Members { get; set; }
        public ICollection<Song> QueuedSongs { get; set; }

        public MusicRoom()
        {

        }

        public MusicRoom(MusicRoomDTO dto)
        {
            Name = dto.Name;
            Genre = dto.Genre;
            Description = dto.Description;
            Members = new HashSet<User>();
            QueuedSongs = new HashSet<Song>();
        }
    }
}
