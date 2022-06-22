using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLTrimRepository : ITrimRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLTrimRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Trim Add(Trim trim)
        {
            dbContext.Trim.Add(trim);
            dbContext.SaveChanges();
            return trim;
        }

        public Trim Delete(int id)
        {
            Trim trim = dbContext.Trim.Find(id);
            if (trim != null)
            {
                dbContext.Remove(trim);
                dbContext.SaveChanges();
            }
            return trim;
        }

        public Trim Update(Trim trimUpdate)
        {
            var trim = dbContext.Trim.Attach(trimUpdate);
            trim.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return trimUpdate;
        }
    }
}
