using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLModelsEnginesRepository : IModelsEnginesRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLModelsEnginesRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(ModelsEngines modelsEngines)
        {
            dbContext.ModelsEngines.Add(modelsEngines);
            dbContext.SaveChanges();
        }
        public void Update(ModelsEngines modelsEnginesUpdate)
        {
            var modelsEngines = dbContext.ModelsEngines.Attach(modelsEnginesUpdate);
            modelsEngines.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            ModelsEngines modelsEngines = dbContext.ModelsEngines.Find(id);
            if (modelsEngines != null)
            {
                dbContext.Remove(modelsEngines);
                dbContext.SaveChanges();
            }
        }
        public ModelsEngines Get(int id)
        {
            return dbContext.ModelsEngines.FindAsync(id).Result;
        }
        public List<ModelsEngines> GetModelsEnginesList()
        {
            return dbContext.ModelsEngines.ToList();
        }
    }
}
