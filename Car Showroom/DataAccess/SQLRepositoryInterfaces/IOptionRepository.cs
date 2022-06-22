using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IOptionRepository
    {
        public void Add(Option option);
        public void Update(Option optionUpdate);
        public void Delete(int id);
        public Option Get(int id);
        public List<Option> GetOptionList();
        public List<Trim> GetTrimsWithOption(Option option);
        public List<Order> GetOrdersWithOption(Option option);
    }
}
