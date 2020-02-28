using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class UserFriendConfiguration : IEntityTypeConfiguration<UserFriend>
    {

        public void Configure(EntityTypeBuilder<UserFriend> builder)
        {
            builder.ToTable("UserFriends");

            builder.HasKey(f => new { f.UserId, f.FriendId });

            builder.HasOne(pt => pt.Friend)
                .WithMany()
                .HasForeignKey(pt => pt.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.User)
                .WithMany(p => p.Friends)
                .HasForeignKey(pt => pt.UserId);


        }
    
    }
}
