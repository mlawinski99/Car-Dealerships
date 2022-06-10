using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ITrimRepository
    {
        Trim Add(Trim trim);
        Trim Update(Trim trimUpdate);
        Trim Delete(int id);
    }
}
