using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IEngineRepository
    {
        Engine Add(Engine engine);
        Engine Update(Engine engineUpdate);
        Engine Delete(int id);
        List<Engine> GetEngineList();
    }
}
