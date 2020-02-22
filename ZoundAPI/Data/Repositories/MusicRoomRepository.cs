using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class MusicRoomRepository : IMusicRoomRepository
    {
        private readonly ZoundContext context;

        public MusicRoomRepository(ZoundContext context)
        {
            this.context = context;
        }

        public void Add(MusicRoom room)
        {
            this.context.MusicRooms.Add(room);
        }

        public MusicRoom GetById(int id)
        {
            return context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id));
        }

        public ICollection<User> GetMembersByRoomId(int id)
        {
            return context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id)).Members;
        }

        public ICollection<Song> GetQueuedSongsByRoomId(int id)
        {
            return context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id)).QueuedSongs;
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
