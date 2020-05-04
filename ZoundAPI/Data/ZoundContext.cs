using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ZoundAPI.Models.Domain;
using ZoundAPI.Data.Configurations;

namespace ZoundAPI.Data
{
    public class ZoundContext : IdentityDbContext
    {
        public DbSet<Song> Songs { get; set; }
        public DbSet<MusicRoom> MusicRooms { get; set; }
        public new DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }
        public DbSet<UserFriend> UserFriends { get; set; }
        public DbSet<UserFriendRequest> UserFriendRequests { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Post> Posts { get; set; }

        public ZoundContext(DbContextOptions<ZoundContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new MusicRoomConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ArtistConfiguration());
            builder.ApplyConfiguration(new UserFriendConfiguration());
            builder.ApplyConfiguration(new UserFriendRequestConfiguration());
            builder.ApplyConfiguration(new FeaturedArtistConfiguration());
            builder.ApplyConfiguration(new FavoriteRoomConfiguration());
            builder.ApplyConfiguration(new PostConfiguration());
        }

    }
}