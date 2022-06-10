using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IModelsTrimsRepository
    {
        ModelsTrims Add(ModelsTrims model);
        ModelsTrims Update(ModelsTrims modelUpdate);
        ModelsTrims Delete(int id);
    }
}
