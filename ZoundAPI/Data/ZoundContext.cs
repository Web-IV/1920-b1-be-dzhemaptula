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
        }

    }
}