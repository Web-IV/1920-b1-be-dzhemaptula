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

            builder.HasKey(f => new { UserId = f.RequestedToID, FriendId = f.RequestedFromID });

            builder.HasOne(pt => pt.RequestedFrom)
                .WithMany()
                .HasForeignKey(pt => pt.RequestedFromID)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.ReuqestedTo)
                .WithMany(p => p.FriendRequests)
                .HasForeignKey(pt => pt.RequestedToID);


        }
    
    }
}
