using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLEngineRepository : IEngineRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLEngineRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Engine Add(Engine engine)
        {
            dbContext.Engines.Add(engine);
            dbContext.SaveChanges();
            return engine;
        }

        public Engine Delete(int id)
        {
            Engine engine = dbContext.Engines.Find(id);
            if (engine != null)
            {
                dbContext.Remove(engine);
                dbContext.SaveChanges();
            }
            return engine;
        }

        public Engine Update(Engine engineUpdate)
        {
            var engine = dbContext.Engines.Attach(engineUpdate);
            engine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return engineUpdate;
        }
        public List<Engine> GetEngineList()
        {
            var engineList = dbContext.Engines.ToList();
            return engineList;
        }
    }
}
