using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IArtistRepository
    {
        Artist GetById(int id);
        Artist GetByName(string name);
        void SaveChanges();
        void Add(Artist artist);
    }
}
