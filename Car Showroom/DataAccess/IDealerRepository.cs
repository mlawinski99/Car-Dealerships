using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IDealerRepository
    {
        Dealer Add(Dealer dealer);
        Dealer Update(Dealer dealer);
        Dealer Delete(int id);
    }
}
