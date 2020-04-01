using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface ISongService
    {
        /// <summary>
        /// Gets song by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
       
        Song GetById(int id);
        /// <summary>
        /// Gets song by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        Song GetByName(string name);

        void SaveChanges();

        void Add(Song song);
    }
}
