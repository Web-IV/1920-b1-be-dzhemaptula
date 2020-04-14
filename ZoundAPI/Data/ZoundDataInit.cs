using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data
{
    public class ZoundDataInit
    {
        private readonly ZoundContext _context;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly ILogger<ZoundDataInit> _logger;
        

        public ZoundDataInit(ZoundContext context, UserManager<IdentityUser> userManager, ILogger<ZoundDataInit> logger)
        {
            this._context = context;
            this._userManager = userManager;
            this._logger = logger;
        }

        public async Task InitAsync()
        {
            //recreate DB under
            _context.Database.EnsureDeleted();
            if (_context.Database.EnsureCreated())
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
            await CreateUser("nicklersberghe", "nick2@gmail.com", password);
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
                await _userManager.CreateAsync(user, password);
            }
            catch (Exception e)
            {
                _logger.LogInformation($"Error from datainit: {e.Message}");
            }
            
        }

        private void InitData()
        {
            var dzhem = new User("Dzhem", "Aptula");
            var nick = new User("Nick", "Lersberghe");
            var tijl = new User("Tijl", "Zwartjes");
            var users = _context.Users;
            dzhem.UserName = "dzhemaptula";
            nick.UserName = "nicklersberghe";
            users.Add(dzhem);
            users.Add(nick);
            users.Add(new User("Janne", "Vschep"));
            users.Add(tijl);
            users.Add(new User("John", "Cena"));
            users.Add(new User("Billie", "Eilish"));
            users.Add(new User("Joseph", "Stalin"));
            users.Add(new User("Napoleon", "Bonaparte"));
            users.Add(new User("Post", "Malone"));
            users.Add(new User("Lil", "Pump"));

            _context.SaveChanges();

            var room1 = new MusicRoom("Drum and bass");


            //add favorite room
            var favorite = new FavoriteRoom(dzhem, room1);
            dzhem.AddFavoriteRoom(favorite);

            //Add friend
            var friend = new UserFriend(dzhem, nick);
            var friendReq = new UserFriendRequest(dzhem, tijl);
            dzhem.AddFriend(friend);
            dzhem.FriendRequests.Add(friendReq);
            _context.UserFriends.Add(friend);
            _context.UserFriendRequests.Add(friendReq);

            
            _context.SaveChanges();
        }
    }
}
