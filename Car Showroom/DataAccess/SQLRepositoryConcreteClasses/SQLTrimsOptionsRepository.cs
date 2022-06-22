using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLTrimsOptionsRepository : ITrimsOptionsRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLTrimsOptionsRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(TrimsOptions trimsOptions)
        {
            dbContext.TrimsOptions.Add(trimsOptions);
            dbContext.SaveChanges();
        }
        public void Update(TrimsOptions trimsOptionsUpdate)
        {
            var trimsOptions = dbContext.TrimsOptions.Attach(trimsOptionsUpdate);
            trimsOptions.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            TrimsOptions trimsOptions = dbContext.TrimsOptions.Find(id);
            if (trimsOptions != null)
            {
                dbContext.Remove(trimsOptions);
                dbContext.SaveChanges();
            }
        }
        public TrimsOptions Get(int id)
        {
            return dbContext.TrimsOptions.FindAsync(id).Result;
        }
        public List<TrimsOptions> GetTrimsOptionsList()
        {
            return dbContext.TrimsOptions.ToList();
        }
    }
}
