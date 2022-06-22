using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IDetailsRepository
    {
        public void Add(Details details);
        public void Update(Details detailsUpdate);
        public void Delete(int id);
        public Details Get(int id);
        public List<Details> GetDetailsList();
    }
}
