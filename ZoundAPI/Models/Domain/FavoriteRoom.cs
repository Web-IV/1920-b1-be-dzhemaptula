﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZoundAPI.Models.Domain
{
    public class FavoriteRoom
    {
        public virtual string UserId { get; set; }
        public virtual User User { get; set; }
        public virtual int RoomId { get; set; }
        public virtual MusicRoom Room { get; set; }
    }
}