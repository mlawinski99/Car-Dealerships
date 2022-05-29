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
        public Dealer Add(Dealer dealer)
        {
            dbContext.Dealer.Add(dealer);
            dbContext.SaveChanges();
            return dealer;
        }

        public Dealer Delete(int id)
        {
            Dealer dealer = dbContext.Dealer.Find(id);
            if (dealer != null)
            {
                dbContext.Remove(dealer);
                dbContext.SaveChanges();
            }
            return dealer;
        }

        public Dealer Update(Dealer dealerUpdate)
        {
            var dealer = dbContext.Dealer.Attach(dealerUpdate);
            dealer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return dealerUpdate;
        }
    }
}
