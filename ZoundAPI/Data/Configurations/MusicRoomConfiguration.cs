using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    internal class MusicRoomConfiguration : IEntityTypeConfiguration<MusicRoom>
    {
        public void Configure(EntityTypeBuilder<MusicRoom> builder)
        {
            builder.ToTable("MusicRooms");
            builder.HasKey(b => b.RoomId);

            builder.Property(b => b.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(b => b.Members);
            builder.HasMany(b => b.QueuedSongs);
        }
    }
}