using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IModelsTrimsRepository
    {
        public void Add(ModelsTrims modelsTrims);
        public void Update(ModelsTrims modelsTrimsUpdate);
        public void Delete(int id);
        public ModelsTrims Get(int id);
        public List<ModelsTrims> GetModelsTrimsList();
    }
}
