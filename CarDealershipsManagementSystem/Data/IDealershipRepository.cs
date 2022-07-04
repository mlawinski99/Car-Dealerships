using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IDealershipRepository
    {
        Dealership Add(Dealership dealer);
        Dealership Update(Dealership dealer);
        Dealership Delete(int id);
        List<Dealership> GetDealershipList();
    }
}
