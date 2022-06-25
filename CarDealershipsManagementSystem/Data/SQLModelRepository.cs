using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLModelRepository : IModelRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLModelRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Model Add(Model model)
        {
            dbContext.Models.Add(model);
            dbContext.SaveChanges();
            return model;
        }

        public Model Delete(int id)
        {
            Model model = dbContext.Models.Find(id);
            if (model != null)
            {
                dbContext.Remove(model);
                dbContext.SaveChanges();
            }
            return model;
        }

        public Model Update(Model modelUpdate)
        {
            var model = dbContext.Models.Attach(modelUpdate);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return modelUpdate;
        }

        public Model GetModel(int modelId)
        {
            var model = dbContext.Models
                .Where(m => m.ModelId == modelId)
                .Include(m => m.Engines)
                .Include(m => m.Equipments)
                .ThenInclude(e => e.Options)
                .FirstOrDefault();
            return model;
        }
        
        public List<Model> GetModelList()
        {

            List<Model> modelList = dbContext.Models.ToList();
            return modelList;
        }
    }
}
