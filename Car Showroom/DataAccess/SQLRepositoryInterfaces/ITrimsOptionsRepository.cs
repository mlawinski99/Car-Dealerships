using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface ITrimsOptionsRepository
    {
        public void Add(TrimsOptions trimsOptions);
        public void Update(TrimsOptions trimsOptionsUpdate);
        public void Delete(int id);
        public TrimsOptions Get(int id);
        public List<TrimsOptions> GetTrimsOptionsList();
    }
}
