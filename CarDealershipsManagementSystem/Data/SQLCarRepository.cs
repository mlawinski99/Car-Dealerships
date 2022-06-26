using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLCarRepository : ICarRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLCarRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Car Add(Car car)
        {
            dbContext.Cars.Add(car);
            dbContext.SaveChanges();
            return car;
        }
        public Car GetCar(int modelId)
        {
            var car = dbContext.Cars.Where(c => c.Model.ModelId == modelId).FirstOrDefault();
            return car;
        }
        
    }
}
