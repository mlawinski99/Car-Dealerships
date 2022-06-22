using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IModelsEnginesRepository
    {
        public void Add(ModelsEngines modelsEngines);
        public void Update(ModelsEngines modelsEnginesUpdate);
        public void Delete(int id);
        public ModelsEngines Get(int id);
        public List<ModelsEngines> GetModelsEnginesList();
    }
}
