using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ICarRepository
    {
        public List<Model> GetModels();
        public Task<Car> GetCar(int modelId);
       
    }
}
