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

        public SQLEngineRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Engine Add(Engine engine)
        {
            dbContext.Engine.Add(engine);
            dbContext.SaveChanges();
            return engine;
        }

        public Engine Delete(int id)
        {
            Engine engine = dbContext.Engine.Find(id);
            if (engine != null)
            {
                dbContext.Remove(engine);
                dbContext.SaveChanges();
            }
            return engine;
        }

        public Engine Update(Engine engineUpdate)
        {
            var engine = dbContext.Engine.Attach(engineUpdate);
            engine.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return engineUpdate;
        }
    }
}
