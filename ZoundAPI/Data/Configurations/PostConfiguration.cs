using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(b => b.PostId);

            builder.Property(b => b.Text)
                .IsRequired()
                .HasMaxLength(1000);

            // builder.HasMany(b => b.Comments).WithOne().HasForeignKey(pt => pt.PostId);

            builder.HasOne(b => b.User).WithMany(b => b.Posts).OnDelete(DeleteBehavior.Cascade);

        }
    }
}
