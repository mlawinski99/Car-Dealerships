using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IModelRepository
    {
        Model Add(Model model);
        Model Update(Model modelUpdate);
        Model Delete(int id);
        Model GetModelById(int modelId);
        List<Model> GetModelList();
    }
}
