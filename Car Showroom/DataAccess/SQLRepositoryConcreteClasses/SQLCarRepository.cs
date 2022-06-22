using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLCarRepository : ICarRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLCarRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Car car)
        {
            dbContext.Car.Add(car);
            dbContext.SaveChanges();
        }
        public void Update(Car carUpdate)
        {
            var car = dbContext.Car.Attach(carUpdate);
            car.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Car car = dbContext.Car.Find(id);
            if (car != null)
            {
                dbContext.Remove(car);
                dbContext.SaveChanges();
            }
        }
        public Car Get(int id)
        {
            return dbContext.Car.FindAsync(id).Result;
        }
        public List<Car> GetCarList()
        {
            return dbContext.Car.ToList();
        }

    }
}
