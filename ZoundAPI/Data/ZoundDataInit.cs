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
        private readonly ZoundContext _context;
        private readonly UserManager<User> _userManger;
        private User _dzhem;
        private User _nick;
        private User _tijl;
        private User _janne;
        private User _aptula;


        public ZoundDataInit(ZoundContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManger = userManager ?? throw new ArgumentException("Error user manager zoundcontext");
        }

        public async Task InitAsync()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                InitUsers().Wait();
                InitFriends();
                _context.SaveChanges();

            }
            else
            {
                throw new Exception("Database Zound could not be created");
            }
        }

        private async Task InitFriends()
        {

        }

        private async Task InitUsers()
        {
            _dzhem = new User() {UserName = "dzhem"};
            _nick = new User() {UserName = "nick"};
            _tijl = new User() {UserName = "tijl"};
            _janne = new User() {UserName = "janne"};
            _context.Users.Add(_dzhem);
            _context.Users.Add(_nick);
            _context.Users.Add(_tijl);
            _context.Users.Add(_janne);
            _context.SaveChanges();


            var friend = new UserFriend(_dzhem, _nick);

            _dzhem.AddFriend(friend);
            _context.Users.Update(_dzhem);
            _context.UserFriends.Add(friend);

            _context.SaveChanges();

            //var result1 = await _userManager.CreateAsync(_memberBob, "Hunter2!Hallo");

            //_aptula = new Member() { UserName = "robbe@hotmail.com", Email = "robbe@hotmail.com" };
            //var result2 = await _userManager.CreateAsync(_memberRobbe, "Hunter2!Hallo");
        }
    }
}
