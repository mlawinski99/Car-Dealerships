using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IModelRepository
    {
        public void Add(Model model);
        public void Update(Model modelUpdate);
        public void Delete(int id);
        public Model Get(int modelId);
        public List<Model> GetModelList();
        public List<Engine> GetEnginesAvailableForModel(Model model);
        public List<Trim> GetTrimsAvailableForModel(Model model);
    }
}
