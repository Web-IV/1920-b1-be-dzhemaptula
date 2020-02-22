using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IMusicRoomRepository
    {
        MusicRoom GetById(int id);
        ICollection<User> GetMembers();
        ICollection<Song> GetQueuedSongs();
        void SaveChanges();
        void Add(MusicRoom room);
    }
}
