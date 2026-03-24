using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Models.Equipments;

namespace WypozyczalniaSprzetu.Services
{
    public class EquipmentService
    {
        private readonly InMemoryStore _store;
        public EquipmentService(InMemoryStore store)
        {
            _store = store;
        }
        public void AddEquipment(Equipment equipment)
        {
            _store.Equipments.Add(equipment);
        }
        public List<Equipment> GetAllEquipments()
        {
            return _store.Equipments;
        }
    }
}
