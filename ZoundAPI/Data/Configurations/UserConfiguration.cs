using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Properties
            builder.HasKey(b => b.UserId);

            builder.Property(b => b.Firstname)
                .HasColumnName("Firstname")
                .HasMaxLength(50);

            builder.Property(b => b.Lastname)
                .HasColumnName("Lastname")
                .HasMaxLength(50);

            builder.Property(b => b.RoomId).IsRequired(false);

            // builder.HasMany(b => b.Comments).WithOne().HasForeignKey(b => b.CommentId);

            // builder.HasMany(x => x.Posts).WithOne().HasForeignKey(b => b.PostId).OnDelete(DeleteBehavior.SetNull);
        }
    }
}