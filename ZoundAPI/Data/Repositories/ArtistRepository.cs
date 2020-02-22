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
        private readonly ZoundContext context;

        public ArtistRepository(ZoundContext context)
        {
            this.context = context;
        }

        public void Add(Artist artist)
        {
            this.context.Artists.Add(artist);
        }

        public Artist GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Artist GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}
