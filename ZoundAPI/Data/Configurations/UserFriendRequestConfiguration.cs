﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class UserFriendRequestConfiguration : IEntityTypeConfiguration<UserFriendRequest>
    {

        public void Configure(EntityTypeBuilder<UserFriendRequest> builder)
        {
            builder.ToTable("UserFriendRequests");

            builder.HasKey(f => new { UserId = f.RequestedToId, FriendId = f.RequestedFromId });

            builder.HasOne(pt => pt.RequestedFrom)
                .WithMany()
                .HasForeignKey(pt => pt.RequestedFromId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(pt => pt.RequestedTo)
                .WithMany(p => p.FriendRequests)
                .HasForeignKey(pt => pt.RequestedToId);


        }
    
    }
}
