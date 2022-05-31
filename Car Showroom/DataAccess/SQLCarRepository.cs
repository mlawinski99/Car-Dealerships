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

        public async Task<Car> GetCar(int modelId)
        {
           var car = await dbContext.Car.FindAsync(modelId);
            return car;
        }

        public Task<Engine> GetEngines(int modelId)
        {
            throw new NotImplementedException();
        }

        public async Task<Model> GetModel(int modelId)
        {
            var model = await dbContext.Model.FindAsync(modelId);
            return model;
        }


        public List<Model> GetModels()
        {
            
            List<Model> modelList = dbContext.Model.ToList();
            return modelList;
        }

        public Task<Option> GetOptions(int modelId)
        {
            throw new NotImplementedException();
        }

        public Task<Trim> GetTrim(int modelId)
        {
            throw new NotImplementedException();
        }
    }
}
