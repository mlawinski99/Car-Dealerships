using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ICarRepository
    {
        //CAR
        public Task<Car> GetCar(int modelId);

        //MODELS
        public List<Model> GetModels();
        public Task<Model> GetModel(int modelId);

        //ENGINES
        public Task<List<Engine>> GetEngineList(List<ModelsEngines> modelsEnginesList);
        public List<ModelsEngines> GetModelsEngines(int modelId);

        //TRIMS
        public List<ModelsTrims> GetModelsTrims(int modelId);
        public Task<List<Trim>> GetTrimList(List<ModelsTrims> modelsTrimsList);
        public Task<List<TrimsOptions>> GetTrimsOptionsList(int trimId);

        //OPTIONS
        public Task<List<Option>> GetOptionsList(List<TrimsOptions> trimsOptionsList);

    }
}
