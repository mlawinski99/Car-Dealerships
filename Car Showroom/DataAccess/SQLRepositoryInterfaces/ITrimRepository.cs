using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ITrimRepository
    {
        public void Add(Trim trim);
        public void Update(Trim trimUpdate);
        public void Delete(int id);
        public Trim Get(int id);
        public List<Trim> GetTrimList();
        public List<Model> GetModelsWithTrim(Trim trim);
        public List<Option> GetOptionsInTrim(Trim trim);
    }
}
