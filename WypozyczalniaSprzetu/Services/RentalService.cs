using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Data;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Rentals;

namespace WypozyczalniaSprzetu.Services
{
    public class RentalService
    {
        private readonly InMemoryStore _store;
        private readonly BorrowingPolicy _borrowingPolicy;
        private readonly PenaltyCalculator _penaltyCalculator;
        public RentalService(InMemoryStore store)
        {
            _store = store;
            _borrowingPolicy = new BorrowingPolicy();
            _penaltyCalculator = new PenaltyCalculator();
        }
        public void RentEquipment(int userId, int equipmentId, DateTime rentReturnEndDate, decimal rentPrice)
        {
            var user = _store.Users.FirstOrDefault(u => u.Id == userId);
            var equipment = _store.Equipments.FirstOrDefault(e => e.Id == equipmentId);
            if (user == null || equipment == null)
            {
                throw new Exception("Użytkownik lub sprzęt nie został znaleziony");
            }
            int activeRentals = _store.Rentals.Count(r => r.UserId == userId && r.ReturnDate == null);
            if (activeRentals >= _borrowingPolicy.GetMaxActiveRentals(user))
            {
                Console.WriteLine("Użytkownik osiągnął limit wypożyczeń");
                return;
            }
            if(equipment.Status == EquipmentStatus.Unvailable)
            {
                Console.WriteLine("Sprzęt jest niedostępny");
                return;
            }
            _store.Rentals.Add(new Rental(user, equipment, DateTime.Now, rentReturnEndDate, rentPrice));
            equipment.Status = EquipmentStatus.Borrowed;
        }
            }
            _store.Rentals.Add(new Rental(user, equipment, DateTime.Now, rentPrice));
            equipment.Status = EquipmentStatus.Rented;
        }
    }
}
