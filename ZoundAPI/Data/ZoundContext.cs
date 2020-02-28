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
        public DbSet<User> Users { get; set; }
        public DbSet<Artist> Artists { get; set; }

        public ZoundContext(DbContextOptions<ZoundContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            /*
            builder.Entity<User>()
                        .HasMany<User>(s => s.Friends)
                        .WithMany<User>(s => s.Friends)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("FriendId");
                            cs.ToTable("UserFriends");
                        });

            builder.Entity<MusicRoom>()
                        .HasMany<User>(s => s.Members)
                        .WithMany(c => c.Rooms)
                        .Map(cs =>
                        {
                            cs.MapLeftKey("UserId");
                            cs.MapRightKey("FriendId");
                            cs.ToTable("UserFriends");
                        });
            */
            builder.ApplyConfiguration(new SongConfiguration());
            builder.ApplyConfiguration(new MusicRoomConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new ArtistConfiguration());
            builder.ApplyConfiguration(new UserFriendConfiguration());
            builder.ApplyConfiguration(new FeaturedArtistConfiguration());
            builder.ApplyConfiguration(new FavoriteRoomConfiguration());
        }

    }
}