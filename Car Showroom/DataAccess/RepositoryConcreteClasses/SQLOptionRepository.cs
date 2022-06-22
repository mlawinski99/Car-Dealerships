using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLOptionRepository : IOptionRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLOptionRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Option Add(Option option)
        {
            dbContext.Option.Add(option);
            dbContext.SaveChanges();
            return option;
        }

        public Option Delete(int id)
        {
            Option option = dbContext.Option.Find(id);
            if (option != null)
            {
                dbContext.Remove(option);
                dbContext.SaveChanges();
            }
            return option;
        }

        public Option Update(Option optionUpdate)
        {
            var option = dbContext.Option.Attach(optionUpdate);
            option.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return optionUpdate;
        }
    }
}
