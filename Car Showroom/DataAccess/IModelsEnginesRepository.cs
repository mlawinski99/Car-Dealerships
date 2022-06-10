using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IModelsEnginesRepository
    {
        ModelsEngines Add(ModelsEngines model);
        ModelsEngines Update(ModelsEngines modelUpdate);
        ModelsEngines Delete(int id);
    }
}
