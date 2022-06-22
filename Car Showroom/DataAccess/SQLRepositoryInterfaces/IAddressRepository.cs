using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public interface IAddressRepository
    {
        public void Add(Address address);
        public void Update(Address address);
        public void Delete(int id);
        public Address Get(int id);
        public List<Address> GetAddressList();
    }
}
