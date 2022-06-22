using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLEngineRepository : IEngineRepository
    {
        private readonly CarDealershipsContext dbContext;
        private SQLModelRepository ModelRepository;
        public SQLEngineRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
            ModelRepository = new SQLModelRepository(dbContext);
        }
        public void Add(Engine engine)
        {
            dbContext.Engine.Add(engine);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Engine engine = dbContext.Engine.Find(id);
            if (engine != null)
            {
                dbContext.Remove(engine);
                dbContext.SaveChanges();
            }
        }
        public void Update(Engine engineUpdate)
        {
            var engine = dbContext.Engine.Attach(engineUpdate);
            engine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public Engine Get(int id)
        {
            return dbContext.Engine.FindAsync(id).Result;
        }
        public List<Engine> GetEngineList()
        {
            return dbContext.Engine.ToList();
        }
        public List<Model> GetModelsWithEngine(Engine engine)
        {
            List<ModelsEngines> modelsEnginesList = engine.ModelsEngines.ToList();
            List<Model> modelList = new List<Model>();
            foreach (ModelsEngines me in modelsEnginesList)
            {
                modelList.Add(ModelRepository.Get(me.ModelId));
            }
            return modelList;
        }
    }
}
