using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Configurations
{
    public class UserFriendConfiguration : IEntityTypeConfiguration<UserFriend>
    {

        public void Configure(EntityTypeBuilder<UserFriend> builder)
        {
            builder.HasKey(bc => new
            {
                bc.UserId,
                bc.FriendId
            });
            
        }
    
    }
}
