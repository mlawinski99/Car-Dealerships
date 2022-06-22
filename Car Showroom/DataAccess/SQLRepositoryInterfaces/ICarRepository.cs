using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ICarRepository
    {
        public void Add(Car car);
        public void Update(Car car);
        public void Delete(int id);
        public Car Get(int id);
        public List<Car> GetCarList();

    }
}
