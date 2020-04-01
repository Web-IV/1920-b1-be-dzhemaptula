using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class SongService : ISongService
    {
        private readonly ZoundContext _context;

        public SongService(ZoundContext context)
        {
            this._context = context;
        }

        public void Add(Song song)
        {
            this._context.Songs.Add(song);
        }

        public Song GetById(int id)
        {
            return _context.Songs.FirstOrDefault(b => b.SongId.Equals(id));
        }

        public Song GetByName(string name)
        {
            return _context.Songs.FirstOrDefault(b => b.Name.Equals(name));
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
