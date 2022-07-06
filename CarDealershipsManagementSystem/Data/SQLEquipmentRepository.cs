using CarDealershipsManagementSystem.Models;
using Microsoft.EntityFrameworkCore;

namespace CarDealershipsManagementSystem.Data
{
    public class SQLEquipmentRepository : IEquipmentRepository
    {
        private readonly ApplicationDbContext dbContext;
        public SQLEquipmentRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public Equipment Add(Equipment equipment)
        {
            dbContext.Equipments.Add(equipment);
            dbContext.SaveChanges();
            return equipment;
        }

        public Equipment Delete(int id)
        {
            Equipment equipment = dbContext.Equipments.Find(id);
            if (equipment != null)
            {
                dbContext.Remove(equipment);
                dbContext.SaveChanges();
            }
            return equipment;
        }

        public List<Equipment> GetEquipmentList()
        {
            List<Equipment> equipmentList = dbContext
                .Equipments
                .Include(e => e.Options)
                .ToList();
            return equipmentList;
        }

        public Equipment Update(Equipment equipmentUpdate)
        {
            var equipment = dbContext.Equipments.Attach(equipmentUpdate);
            equipment.State = EntityState.Modified;
            dbContext.SaveChanges();
            return equipmentUpdate;
        }
        public Equipment GetEquipmentById(int equipmentId)
        {
            return dbContext.Equipments
                .Where(m => m.EquipmentId == equipmentId)
                .Include(e => e.Options)
                .FirstOrDefault();
        }
    }
}
