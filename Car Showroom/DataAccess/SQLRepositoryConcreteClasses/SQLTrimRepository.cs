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
        private SQLModelRepository ModelRepository;
        private SQLOptionRepository OptionRepository;
        public SQLTrimRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
            ModelRepository = new SQLModelRepository(dbContext);
            OptionRepository = new SQLOptionRepository(dbContext);
        }
        public void Add(Trim trim)
        {
            dbContext.Trim.Add(trim);
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Trim trim = dbContext.Trim.Find(id);
            if (trim != null)
            {
                dbContext.Remove(trim);
                dbContext.SaveChanges();
            }
        }
        public void Update(Trim trimUpdate)
        {
            var trim = dbContext.Trim.Attach(trimUpdate);
            trim.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public Trim Get(int id)
        {
            return dbContext.Trim.FindAsync(id).Result;
        }
        public List<Trim> GetTrimList()
        {
            return dbContext.Trim.ToList();
        }
        public List<Model> GetModelsWithTrim(Trim trim)
        {
            List<ModelsTrims> modelsTrimsList = trim.ModelsTrims.ToList();
            List<Model> modelList = new List<Model>();
            foreach (ModelsTrims mt in modelsTrimsList)
            {
                modelList.Add(ModelRepository.Get(mt.ModelId));
            }
            return modelList;
        }
        public List<Option> GetOptionsInTrim(Trim trim)
        {
            List<TrimsOptions> trimsOptionList = trim.TrimsOptions.ToList();
            List<Option> optionList = new List<Option>();
            foreach (TrimsOptions to in trimsOptionList)
            {
                optionList.Add(OptionRepository.Get(to.OptionId));
            }
            return optionList;
        }
    }
}
