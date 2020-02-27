using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class UserFriend
    {
        
        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public string UserId { get; set; }

        [ForeignKey(nameof(FriendId))]
        public virtual User Friend { get; set; }
        public string FriendId { get; set; }
    }
}
