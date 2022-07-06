using CarDealershipsManagementSystem.Data;
using CarDealershipsManagementSystem.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLDealershipRepository : IDealershipRepository
    {
        private readonly ApplicationDbContext dbContext;

        public SQLDealershipRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Dealership Add(Dealership dealer)
        {
            dbContext.Dealerships.Add(dealer);
            dbContext.SaveChanges();
            return dealer;
        }

        public Dealership Delete(int id)
        {
            Dealership dealer = dbContext.Dealerships.Find(id);
            if (dealer != null)
            {
                dbContext.Remove(dealer);
                dbContext.SaveChanges();
            }
            return dealer;
        }

        public Dealership Update(Dealership dealerUpdate)
        {
            var dealer = dbContext.Dealerships.Attach(dealerUpdate);
            dealer.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            dbContext.SaveChanges();
            return dealerUpdate;
        }

        public List<Dealership> GetDealershipList()
        {
            var dealerList = dbContext.Dealerships.Include(d => d.Address).ToList();
            return dealerList;
        }

        public Dealership GetDealershipById(int dealershipId)
        {
            return dbContext.Dealerships.Find(dealershipId);
        }
    }
}
