using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLModelRepository : IModelRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLModelRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Model Add(Model model)
        {
            dbContext.Model.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public Model Delete(int id)
        {
            Model model = dbContext.Model.Find(id);
            if (model != null)
            {
                dbContext.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public Model Update(Model modelUpdate)
        {
            var model = dbContext.Model.Attach(modelUpdate);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return modelUpdate;
        }
    }
}
