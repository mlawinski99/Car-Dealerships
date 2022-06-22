using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IEngineRepository
    {
        public void Add(Engine engine);
        public void Update(Engine engineUpdate);
        public void Delete(int id);
        public Engine Get(int id);
        public List<Engine> GetEngineList();
        public List<Model> GetModelsWithEngine(Engine engine);
    }
}
