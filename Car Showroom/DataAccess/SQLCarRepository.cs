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
            var car = (Car)dbContext.Car.Where(c => c.ModelId == modelId);
            //where modelId == modelId
            return car;
        }

        public List<ModelsEngines> GetModelsEngines(int modelId)
        {
            var modelsEngines = dbContext.ModelsEngines.Where(m => m.ModelId == modelId).ToList();
            return modelsEngines;
        }

        public async Task<List<Engine>> GetEngineList(List<ModelsEngines> modelsEnginesList)
        {
            //var modelsEnginesList = GetModelsEngines(modelId);
            List<Engine> engineList = new List<Engine>();
            foreach(var element in modelsEnginesList)
            {
                var engine = await dbContext.Engine.FindAsync(element.EngineId);
                engineList.Add(engine);

            }
            return engineList;
        }

        public List<ModelsTrims> GetModelsTrims(int modelId)
        {
            var modelsTrims = dbContext.ModelsTrims.Where(m => m.ModelId == modelId).ToList();
            return modelsTrims;
        }

        public async Task<List<Trim>> GetTrimList(List<ModelsTrims> modelsTrimsList)
        {
            //var modelsTrimsList = GetModelsTrims(modelId);
            List<Trim> trimList = new List<Trim>();
            foreach (var element in modelsTrimsList)
            {
                var trim = await dbContext.Trim.FindAsync(element.TrimId);
                trimList.Add(trim);

            }
            return trimList;
        }

        public async Task<Model> GetModel(int modelId)
        {
            var model = await dbContext.Model.FindAsync(modelId);
            return model;
        }


        public List<Model> GetModelList()
        {
            
            List<Model> modelList = dbContext.Model.ToList();
            return modelList;
        }
        public async Task <List<TrimsOptions>> GetTrimsOptionsList(int trimId)
        {
            var trimsOptionsList = dbContext.TrimsOptions.Where(t => t.TrimId == trimId).ToList();
            return trimsOptionsList;

        }
        public async Task<List<Option>> GetOptionsList(List<TrimsOptions> trimsOptionsList)
        {
            List<Option> optionsList = new List<Option>();
            foreach (var element in trimsOptionsList)
            {
                var option = await dbContext.Option.FindAsync(element.OptionId);
                optionsList.Add(option);
            }
            return optionsList;
        }

        public async Task<List<Engine>> GetEngineList()
        {
            var engineList = dbContext.Engine.ToList();
            return engineList;
        }

        public async Task<List<Trim>> GetTrimList()
        {
            var trimList = dbContext.Trim.ToList();
            return trimList;
        }
    }
}
