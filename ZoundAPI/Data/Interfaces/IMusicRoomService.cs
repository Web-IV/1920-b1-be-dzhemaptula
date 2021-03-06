﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface IMusicRoomService
    {
        MusicRoom GetById(int id);
        ICollection<User> GetMembersByRoomId(int id);
        Queue<Song> GetQueuedSongsByRoomId(int id);
    }
}
