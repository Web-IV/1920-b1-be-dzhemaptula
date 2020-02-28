using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class FeaturedArtistConfiguration : IEntityTypeConfiguration<FeaturedArtist>
    {

        public void Configure(EntityTypeBuilder<FeaturedArtist> builder)
        {
            builder.ToTable("FeaturedArtists");

            builder.HasKey(f => new { f.ArtistId, f.SongId });

            builder.HasOne(pt => pt.Artist)
                .WithMany()
                .HasForeignKey(pt => pt.ArtistId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.Song)
                .WithMany(p => p.FeaturedArtists)
                .HasForeignKey(pt => pt.SongId);




        }
    
    }
}
