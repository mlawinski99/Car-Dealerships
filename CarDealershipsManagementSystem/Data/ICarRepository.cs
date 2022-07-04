using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface ICarRepository
    {
        public Car GetCar(int modelId);
        public Car Add(Car car);
    }
}
