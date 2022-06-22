using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly CarDealershipsContext dbContext;

        public SQLAddressRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Address Add(Address address)
        {
            dbContext.Address.Add(address);
            dbContext.SaveChanges();
            return address;
        }

        public Address Delete(int id)
        {
            Address adress = dbContext.Address.Find(id);
            if (adress != null)
            {
                dbContext.Remove(adress);
                dbContext.SaveChanges();
            }
            return adress;
        }

        public Address Update(Address addressUpdate)
        {
            var address = dbContext.Address.Attach(addressUpdate);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return addressUpdate;
        }
    }
}
