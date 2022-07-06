using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLOptionRepository : IOptionRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SQLOptionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Option Add(Option option)
        {
            dbContext.Options.Add(option);
            dbContext.SaveChanges();
            return option;
        }
        public Option Delete(int id)
        {
            Option option = dbContext.Options.Find(id);
            if (option != null)
            {
                dbContext.Remove(option);
                dbContext.SaveChanges();
            }
            return option;
        }
        public Option Update(Option optionUpdate)
        {
            var option = dbContext.Options.Attach(optionUpdate);
            option.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return optionUpdate;
        }
        public List<Option> GetOptionList()
        {
            var optionList = dbContext.Options.ToList();
            return optionList;
        }

        public Option GetOptionById(int optionId)
        {
            return dbContext.Options.Find(optionId);
        }
    }
}
