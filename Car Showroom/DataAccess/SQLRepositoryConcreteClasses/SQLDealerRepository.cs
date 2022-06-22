using Car_Showroom.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Car_Showroom.DataAccess
{
    public class SQLDealerRepository : IDealerRepository
    {
        private readonly CarDealershipsContext dbContext;
        public SQLDealerRepository(CarDealershipsContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Dealer dealer)
        {
            dbContext.Dealer.Add(dealer);
            dbContext.SaveChanges();
        }
        public void Update(Dealer dealerUpdate)
        {
            var dealer = dbContext.Dealer.Attach(dealerUpdate);
            dealer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
        }
        public void Delete(int id)
        {
            Dealer dealer = dbContext.Dealer.Find(id);
            if (dealer != null)
            {
                dbContext.Remove(dealer);
                dbContext.SaveChanges();
            }
        }
        public Dealer Get(int id)
        {
            return dbContext.Dealer.FindAsync(id).Result;
        }
        public List<Dealer> GetDealerList()
        {
            return dbContext.Dealer.ToList();
        }
    }
}
