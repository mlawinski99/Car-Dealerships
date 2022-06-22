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
        private SQLEngineRepository EngineRepository;
        private SQLTrimRepository TrimRepository;
        public SQLModelRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
            EngineRepository = new SQLEngineRepository(dbContext);
            TrimRepository = new SQLTrimRepository(dbContext);
        }
        public void Add(Model model)
        {
            dbContext.Model.Add(model);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Model model = dbContext.Model.Find(id);
            if (model != null)
            {
                dbContext.Remove(model);
                dbContext.SaveChanges();
            }
        }
        public void Update(Model modelUpdate)
        {
            var model = dbContext.Model.Attach(modelUpdate);
            model.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public Model Get(int id)
        {
            return dbContext.Model.FindAsync(id).Result;
        }
        public List<Model> GetModelList()
        {
            return dbContext.Model.ToList();
        }
        public List<Engine> GetEnginesAvailableForModel(Model model)
        {
            List<ModelsEngines> modelsEnginesList = model.ModelsEngines.ToList();
            List<Engine> engineList = new List<Engine>();
            foreach (ModelsEngines me in modelsEnginesList)
            {
                engineList.Add(EngineRepository.Get(me.EngineId));
            }
            return engineList;
        }
        public List<Trim> GetTrimsAvailableForModel(Model model)
        {
            List<ModelsTrims> modelsTrimsList = model.ModelsTrims.ToList();
            List<Trim> trimList = new List<Trim>();
            foreach (ModelsTrims mt in modelsTrimsList)
            {
                trimList.Add(TrimRepository.Get(mt.TrimId));
            }
            return trimList;
        }
    }
}
