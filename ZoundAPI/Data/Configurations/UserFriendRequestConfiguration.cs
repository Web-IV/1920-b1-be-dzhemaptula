using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class UserFriendRequestConfiguration : IEntityTypeConfiguration<UserFriendRequest>
    {

        public void Configure(EntityTypeBuilder<UserFriendRequest> builder)
        {
            builder.ToTable("UserFriendRequests");

            builder.HasKey(f => new { f.UserId, f.FriendId });

            builder.HasOne(pt => pt.Friend)
                .WithMany()
                .HasForeignKey(pt => pt.FriendId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.User)
                .WithMany(p => p.FriendRequests)
                .HasForeignKey(pt => pt.UserId);


        }
    
    }
}
