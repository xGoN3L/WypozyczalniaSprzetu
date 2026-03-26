using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Data;
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
        public void ShowAllEquipment()
        {
            Console.WriteLine("Cały sprzęt: ");
            _store.Equipments.ForEach(x => Console.WriteLine(x));
            Console.WriteLine("_______________\n");
        }
        public void ShowAvailableEquipment()
        {
            Console.WriteLine("Dostępny sprzęt do wypożyczenia: ");
            _store.Equipments.Where(x => x.Status == EquipmentStatus.Available).ToList().ForEach(x => Console.WriteLine(x));
            Console.WriteLine("_______________\n");
        }
        public void SetEquipmentAsUnavailable(int equipmentId)
        {
            var equipment = _store.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (equipment == null)
            {
                Console.WriteLine("Sprzęt nie został znaleziony\n"); 
                return;
            }
            equipment.Status = EquipmentStatus.Unvailable;
        }
    }
}
