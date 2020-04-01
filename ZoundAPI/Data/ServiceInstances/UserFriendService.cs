using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Data.Repositories
{
    public class UserFriendService : IUserFriendService
    {
        private readonly ZoundContext _context;

        public UserFriendService(ZoundContext context)
        {
            this._context = context;
        }

        public void CreateFriendship(string id, string friendId)
        {

        }

    }
}
