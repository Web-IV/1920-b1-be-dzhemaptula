using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data
{
    public class ZoundDataInit
    {
        private ZoundContext _context;
        private readonly UserManager<User> _userManger;


        public ZoundDataInit(ZoundContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManger = userManager ?? throw new ArgumentException("Error");
        }

        public async void InitAsync()
        {
            _context.Database.EnsureDeleted();
            _context.Database.EnsureCreated();
        }
    }
}
