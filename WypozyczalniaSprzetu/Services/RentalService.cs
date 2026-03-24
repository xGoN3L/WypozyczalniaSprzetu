using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Rentals;

namespace WypozyczalniaSprzetu.Services
{
    public class RentalService
    {
        private readonly InMemoryStore _store;
        private readonly BorrowingPolicy _borrowingPolicy;
        private readonly PenaltyCalculator _penaltyCalculator;
        public RentalService(InMemoryStore store, BorrowingPolicy borrowingPolicy, PenaltyCalculator penaltyCalculator)
        {
            _store = store;
            _borrowingPolicy = borrowingPolicy;
            _penaltyCalculator = penaltyCalculator;
        }
        public void RentEquipment(int userId, int equipmentId, decimal rentPrice)
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
                throw new Exception("Użytkownik osiągnął limit wypożyczeń");
            }
            _store.Rentals.Add(new Rental(user, equipment, DateTime.Now, rentPrice));
            equipment.Status = EquipmentStatus.Rented;
        }
    }
}
