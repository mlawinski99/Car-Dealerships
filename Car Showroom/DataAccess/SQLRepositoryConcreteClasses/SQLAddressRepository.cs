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
        public void Add(Address address)
        {
            dbContext.Address.Add(address);
            dbContext.SaveChanges();
        }
        public void Update(Address addressUpdate)
        {
            var address = dbContext.Address.Attach(addressUpdate);
            address.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Address adress = dbContext.Address.Find(id);
            if (adress != null)
            {
                dbContext.Remove(adress);
                dbContext.SaveChanges();
            }
        }
        public Address Get(int id)
        {
            return dbContext.Address.FindAsync(id).Result;
        }
        public List<Address> GetAddressList()
        {
            return dbContext.Address.ToList();
        }
    }
}
