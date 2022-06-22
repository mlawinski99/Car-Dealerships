using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLModelsTrimsRepository : IModelsTrimsRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLModelsTrimsRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(ModelsTrims modelsTrims)
        {
            dbContext.ModelsTrims.Add(modelsTrims);
            dbContext.SaveChanges();
        }
        public void Update(ModelsTrims modelsTrimsUpdate)
        {
            var ModelsTrims = dbContext.ModelsTrims.Attach(modelsTrimsUpdate);
            ModelsTrims.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            ModelsTrims modelsTrims = dbContext.ModelsTrims.Find(id);
            if (modelsTrims != null)
            {
                dbContext.Remove(modelsTrims);
                dbContext.SaveChanges();
            }
        }
        public ModelsTrims Get(int id)
        {
            return dbContext.ModelsTrims.FindAsync(id).Result;
        }
        public List<ModelsTrims> GetModelsTrimsList()
        {
            return dbContext.ModelsTrims.ToList();
        }
    }
}
