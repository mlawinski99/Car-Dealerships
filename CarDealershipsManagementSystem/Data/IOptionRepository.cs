using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarDealershipsManagementSystem.Data
{
    public interface IOptionRepository
    {
        Option Add(Option option);
        Option Update(Option optionUpdate);
        Option Delete(int id);
        List<Option> GetOptionList();
    }
}
