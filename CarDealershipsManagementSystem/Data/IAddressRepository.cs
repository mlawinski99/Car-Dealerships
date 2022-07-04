using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IAddressRepository
    {
        Address Add(Address address);
        Address Update(Address address);
        Address Delete(int id);
    }
}
