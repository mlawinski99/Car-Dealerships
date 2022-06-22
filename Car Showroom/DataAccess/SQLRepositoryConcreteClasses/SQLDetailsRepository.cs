using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLDetailsRepository : IDetailsRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLDetailsRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Details details)
        {
            dbContext.Details.Add(details);
            dbContext.SaveChanges();
        }
        public void Update(Details detailsUpdate)
        {
            var details = dbContext.Details.Attach(detailsUpdate);
            details.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Details details = dbContext.Details.Find(id);
            if (details != null)
            {
                dbContext.Remove(details);
                dbContext.SaveChanges();
            }
        }
        public Details Get(int id)
        {
            return dbContext.Details.FindAsync(id).Result;
        }
        public List<Details> GetDetailsList()
        {
            return dbContext.Details.ToList();
        }
    }
}
