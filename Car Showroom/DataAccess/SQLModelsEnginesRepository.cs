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
        public ModelsEngines Add(ModelsEngines model)
        {
            dbContext.ModelsEngines.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public ModelsEngines Delete(int id)
        {
            ModelsEngines model = dbContext.ModelsEngines.Find(id);
            if (model != null)
            {
                dbContext.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public ModelsEngines Update(ModelsEngines modelUpdate)
        {
            var model = dbContext.ModelsEngines.Attach(modelUpdate);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return modelUpdate;
        }
    }
}
