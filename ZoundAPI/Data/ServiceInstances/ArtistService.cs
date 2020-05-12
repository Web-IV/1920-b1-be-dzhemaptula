using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Data.Interfaces;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.ServiceInstances
{
    public class ArtistService : IArtistService
    {
        private readonly ZoundContext _context;

        public ArtistService(ZoundContext context)
        {
            this._context = context;
        }

        public Artist GetById(int id)
        {
            return this._context.Artists.FirstOrDefault(x => x.ArtistId.Equals(id));
        }

        public Artist GetByName(string name)
        {
            return this._context.Artists.FirstOrDefault(x => x.Name.Equals(name));
        }
    }
}
