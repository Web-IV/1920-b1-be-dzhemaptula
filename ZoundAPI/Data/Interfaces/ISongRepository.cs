using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface ISongRepository
    {
        Song GetById(int id);
        Song GetByName(string name);
        void SaveChanges();
        void Add(Song song);
    }
}
