using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Diagnostics;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data
{
    public class ZoundDataInit
    {
        private readonly ZoundContext _context;
        private readonly UserManager<IdentityUser> _userManger;
        private readonly RoleManager<IdentityRole> _roleManager;
        private User _dzhem;
        private User _nick;
        private User _tijl;
        private User _janne;
        private User _aptula;


        public ZoundDataInit(ZoundContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManger = userManager ?? throw new ArgumentException("Error user manager zoundcontext");
            _roleManager = roleManager ?? throw new ArgumentException("Error role manager zoundcontext");
        }

        public void InitAsync()
        {
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
            {
                InitData();

            }
            else
            {
                throw new Exception("Database Zound could not be created");
            }
        }


        private void InitData()
        {
            var Users = _context.Users;

            _dzhem = new User("Dzhem", "Aptula");
            _nick = new User("Nick", "Lersberghe");
            Users.Add(_dzhem);
            Users.Add(_nick);
            Users.Add(new User("Janne", "Vschep"));
            Users.Add(new User("Tijl", "Zwartjes"));
            Users.Add(new User("John", "Cena"));
            Users.Add(new User("Billie", "Eilish"));
            Users.Add(new User("Joseph", "Stalin"));
            Users.Add(new User("Napoleon", "Bonaparte"));
            Users.Add(new User("Post", "Malone"));
            Users.Add(new User("Lil", "Pump"));

            _context.SaveChanges();

            var MusicRooms = _context.MusicRooms;

            var _room1 = new MusicRoom("Drum and bass");


            //add favorite room
            var favorite = new FavoriteRoom(_dzhem, _room1);
            _dzhem.AddFavoriteRoom(favorite);

            //Add friend
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
