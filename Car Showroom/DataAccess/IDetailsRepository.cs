using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IDetailsRepository
    {
        Details Add(Details details);
        Details Update(Details detailsUpdate);
        Details Delete(int id);
    }
}
