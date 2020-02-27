using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class SongRepository : ISongRepository
    {
        private readonly ZoundContext context;

        public SongRepository(ZoundContext context)
        {
            this.context = context;
        }

        public void Add(Song song)
        {
            this.context.Songs.Add(song);
        }

        public Song GetById(int id)
        {
            return context.Songs.FirstOrDefault(b => b.SongId.Equals(id));
        }

        public Song GetByName(string name)
        {
            return context.Songs.FirstOrDefault(b => b.Name.Equals(name));
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
