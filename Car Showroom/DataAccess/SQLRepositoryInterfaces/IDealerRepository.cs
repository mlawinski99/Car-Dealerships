using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IDealerRepository
    {
        public void Add(Dealer dealer);
        public void Update(Dealer dealer);
        public void Delete(int id);
        public Dealer Get(int id);
        public List<Dealer> GetDealerList();
    }
}
