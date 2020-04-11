using System.Collections.Generic;
using ZoundAPI.DTOs;

namespace ZoundAPI.Models.Domain
{
    public class MusicRoom
    {
        public int RoomId { get; set; }
        public string Name { get; set; }
        public string Genre { get; private set; }
        public string Description { get; set; }
        public ICollection<User> Members { get; set; }
        public Queue<Song> QueuedSongs { get; set; }

        public MusicRoom()
        {
            Members = new HashSet<User>();
            QueuedSongs = new Queue<Song>();
        }

        public MusicRoom(MusicRoomDto dto):this()
        {
            Name = dto.Name;
            Genre = dto.Genre;
            Description = dto.Description;
        }

        public MusicRoom(string name):this()
        {
            Name = name;
        }

        
    }
}
