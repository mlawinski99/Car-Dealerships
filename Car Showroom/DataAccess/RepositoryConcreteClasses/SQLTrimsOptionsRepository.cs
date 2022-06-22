using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLTrimsOptionsRepository : ITrimsOptions
    {
        private readonly CarDealershipsContext dbContext;

        public SQLTrimsOptionsRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public TrimsOptions Add(TrimsOptions trimsOptions)
        {
            dbContext.TrimsOptions.Add(trimsOptions);
            dbContext.SaveChanges();
            return trimsOptions;
        }

        public TrimsOptions Delete(int id)
        {
            TrimsOptions trimsOptions = dbContext.TrimsOptions.Find(id);
            if (trimsOptions != null)
            {
                dbContext.Remove(trimsOptions);
                dbContext.SaveChanges();
            }
            return trimsOptions;
        }

        public TrimsOptions Update(TrimsOptions trimsOptionsUpdate)
        {
            var trimsOptions = dbContext.TrimsOptions.Attach(trimsOptionsUpdate);
            trimsOptions.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return trimsOptionsUpdate;
        }
    }
}
