﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            //Properties
            builder.Property(b => b.Firstname)
                .HasColumnName("Firstname")
                .HasMaxLength(50);

            builder.Property(b => b.Lastname)
                .HasColumnName("Lastname")
                .HasMaxLength(50);

            builder.HasMany(b => b.Friends);
                
        }
    }
}