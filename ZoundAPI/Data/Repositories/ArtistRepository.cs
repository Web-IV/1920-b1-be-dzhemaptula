using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Repositories
{
    public class ArtistRepository : IArtistRepository
    {
        private readonly ZoundContext _context;

        public ArtistRepository(ZoundContext context)
        {
            this._context = context;
        }

        public void Add(Artist artist)
        {
            this._context.Artists.Add(artist);
        }

        public Artist GetById(int id)
        {
            return this._context.Artists.FirstOrDefault(x => x.ArtistId.Equals(id));
        }

        public Artist GetByName(string name)
        {
            return this._context.Artists.FirstOrDefault(x => x.Name.Equals(name));
        }

        public void SaveChanges()
        {
            this._context.SaveChanges();
        }
    }
}
