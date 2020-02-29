using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Data.Repositories
{
    public class UserFriendRepository : IUserFriendrepository
    {
        private readonly ZoundContext _context;

        public UserFriendRepository(ZoundContext context)
        {
            this._context = context;
        }

        public void CreateFriendship(string id, string friendId)
        {

        }

    }
}
