using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class MusicRoomService : IMusicRoomService
    {
        private readonly ZoundContext _context;

        public MusicRoomService(ZoundContext context)
        {
            this._context = context;
        }

        public MusicRoom GetById(int id)
        {
            return _context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id));
        }

        public ICollection<User> GetMembersByRoomId(int id) =>
            _context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id))?.Members;

        public Queue<Song> GetQueuedSongsByRoomId(int id)
        {
            return _context.MusicRooms.FirstOrDefault(b => b.RoomId.Equals(id))?.QueuedSongs;
        }
    }
}
