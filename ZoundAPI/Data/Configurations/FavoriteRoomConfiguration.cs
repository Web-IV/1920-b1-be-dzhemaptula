using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class FavoriteRoomConfiguration : IEntityTypeConfiguration<FavoriteRoom>
    {

        public void Configure(EntityTypeBuilder<FavoriteRoom> builder)
        {
            builder.ToTable("FavoriteRooms");

            builder.HasKey(f => new { f.RoomId, f.UserId });

            builder.HasOne(pt => pt.Room)
                .WithMany()
                .HasForeignKey(pt => pt.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.User)
                .WithMany(p => p.FavoriteRooms)
                .HasForeignKey(pt => pt.UserId);




        }
    
    }
}
