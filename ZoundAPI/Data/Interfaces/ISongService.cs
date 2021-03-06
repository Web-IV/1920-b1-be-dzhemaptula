﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ZoundAPI.Models.Domain;

namespace ZoundAPI.Data.Interfaces
{
    public interface ISongService
    {
        Song GetById(int id);
        Song GetByName(string name);
    }
}
