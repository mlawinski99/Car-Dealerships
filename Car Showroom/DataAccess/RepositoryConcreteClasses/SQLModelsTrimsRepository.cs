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
        public ModelsTrims Add(ModelsTrims model)
        {
            dbContext.ModelsTrims.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public ModelsTrims Delete(int id)
        {
            ModelsTrims model = dbContext.ModelsTrims.Find(id);
            if (model != null)
            {
                dbContext.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public ModelsTrims Update(ModelsTrims modelUpdate)
        {
            var model = dbContext.ModelsTrims.Attach(modelUpdate);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return modelUpdate;
        }
    }
}
