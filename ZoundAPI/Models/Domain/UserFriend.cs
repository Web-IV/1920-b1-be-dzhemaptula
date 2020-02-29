﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public sealed class UserFriend
    {

        public UserFriend(User user, User friend)
        {
            User = user;
            Friend = friend;
        }

        [ForeignKey(nameof(UserId))]
        public User User { get; set; }
        public string UserId => User.Id;

        [ForeignKey(nameof(FriendId))]
        public User Friend { get; set; }
        public string FriendId => Friend.Id;
    }
}
