using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IAddressRepository
    {
        Address Add(Address address);
        Address Update(Address address);
        Address Delete(int id);
    }
}
