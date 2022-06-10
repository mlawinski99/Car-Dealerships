using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ITrimsOptions
    {
        TrimsOptions Add(TrimsOptions trimsOptions);
        TrimsOptions Update(TrimsOptions trimsOptionsUpdate);
        TrimsOptions Delete(int id);
    }
}
