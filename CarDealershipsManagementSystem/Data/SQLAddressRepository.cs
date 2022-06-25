using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLAddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLAddressRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Address Add(Address address)
        {
            dbContext.Adresses.Add(address);
            dbContext.SaveChanges();
            return address;
        }

        public Address Delete(int id)
        {
            Address adress = dbContext.Adresses.Find(id);
            if (adress != null)
            {
                dbContext.Remove(adress);
                dbContext.SaveChanges();
            }
            return adress;
        }

        public Address Update(Address addressUpdate)
        {
            var address = dbContext.Adresses.Attach(addressUpdate);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return addressUpdate;
        }
    }
}
