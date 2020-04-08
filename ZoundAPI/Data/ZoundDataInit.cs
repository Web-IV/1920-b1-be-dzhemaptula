using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data
{
    public class ZoundDataInit
    {
        private readonly ZoundContext Context;
        private readonly UserManager<IdentityUser> UserManager;
        private readonly RoleManager<IdentityRole> RoleManager;

        public ZoundDataInit(ZoundContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            Context = context;
            UserManager = userManager;
            RoleManager = roleManager;
        }

        public async Task InitAsync()
        {
            Context.Database.EnsureDeleted();
            if (Context.Database.EnsureCreated())
            {
                InitData();
                await InitializeUsers();
            }
            else
            {
                throw new Exception("Database Zound could not be created");
            }
        }
        private async Task InitializeUsers()
        {
            const string password = "password";
            await CreateUser("nicklersberghe","nick@gmail.com", password);
            await CreateUser("dzhemaptula", "dzhem.aptula@gmail.com",password);
            await CreateUser("tijlzwartjes", "tijl@gmail.com", password);
            await CreateUser("jannevschep", "janne@vsche.pp", password);
            await CreateUser("josephstalin", "joseph@stal.in", password);
            await CreateUser("johncena", "john@ce.na", password);
        }

        private async Task CreateUser(string username, string email, string password)
        {
            var user = new IdentityUser { UserName = username, Email = email };
            try
            {
                await UserManager.CreateAsync(user, password);
            }
            catch (Exception e)
            {
                Console.WriteLine("ERRROOOOR: " + e.Message);
            }
            
        }

        private void InitData()
        {
            var Users = Context.Users;

            var _dzhem = new User("Dzhem", "Aptula");
            var _nick = new User("Nick", "Lersberghe");
            _dzhem.UserName = "dzhemaptula";
            _nick.UserName = "nicklersberghe";
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

            Context.SaveChanges();

            var MusicRooms = Context.MusicRooms;

            var _room1 = new MusicRoom("Drum and bass");


            //add favorite room
            var favorite = new FavoriteRoom(_dzhem, _room1);
            _dzhem.AddFavoriteRoom(favorite);

            //Add friend
            var friend = new UserFriend(_dzhem, _nick);
            _dzhem.AddFriend(friend);
            Context.Users.Update(_dzhem);
            Context.UserFriends.Add(friend);
            
            Context.SaveChanges();
        }
    }
}
