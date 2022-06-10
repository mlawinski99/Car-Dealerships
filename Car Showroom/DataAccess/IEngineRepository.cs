﻿using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IEngineRepository
    {
        Engine Add(Engine engine);
        Engine Update(Engine engineUpdate);
        Engine Delete(int id);
    }
}