using CarDealershipsManagementSystem.Models;

namespace CarDealershipsManagementSystem.Data
{
    public interface IEquipmentRepository
    {
        Equipment Add(Equipment equipment);
        Equipment Update(Equipment equipmentUpdate);
        Equipment Delete(int id);
        List<Equipment> GetEquipmentList();
    }
}
