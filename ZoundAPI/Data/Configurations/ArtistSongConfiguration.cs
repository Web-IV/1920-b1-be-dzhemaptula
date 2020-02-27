using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class ArtistSongConfiguration : IEntityTypeConfiguration<ArtistSong>
    {

        public void Configure(EntityTypeBuilder<ArtistSong> builder)
        {
            builder.ToTable("UserFriends");

            builder.HasKey(f => new { f.ArtistId, f.SongId });

            builder.HasOne(pt => pt.Song)
                .WithMany()
                .HasForeignKey(pt => pt.SongId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.Artist)
                .WithMany(p => p.Songs)
                .HasForeignKey(pt => pt.UserId);


        }
    
    }
}
