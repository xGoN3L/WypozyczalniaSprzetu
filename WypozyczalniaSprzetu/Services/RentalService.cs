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
                Console.WriteLine("Użytkownik lub sprzęt nie został znaleziony");
            }
            int activeRentals = _store.Rentals.Count(r => r.Borrower.Id == userId && r.RentReturnDate == null);
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
        public Rental GetRentalForEquipment(int equipmentId)
        {
            var rental = _store.Rentals.FirstOrDefault(r => r.EquipmentRented.Id == equipmentId && r.RentReturnDate == null);
            if (rental == null)
            {
                Console.WriteLine("Sprzęt nie jest aktualnie wypożyczony");
                return null;
                //TODO
            }
            else
            {
                return rental;
            }
        }
        public void ReturnEquipment(int rentalId)
        {
            var rental = _store.Rentals.FirstOrDefault(r => r.Id == rentalId);
            if (rental == null || rental.RentReturnDate != null)
            {
                Console.WriteLine("Nieprawidłowy identyfikator wypożyczenia lub sprzęt już został zwrócony");
                return;
            }
            rental.RentReturnDate = DateTime.Now;
            rental.EquipmentRented.Status = EquipmentStatus.Available;
            decimal penalty = _penaltyCalculator.CalculatePenalty(rental.RentReturnEndDate, DateTime.Now);
            if (penalty > 0)
            {
                Console.WriteLine($"Należna kara za spóźnienie: {penalty}");
            }
            rental.RentFine = penalty;
        }
        public void ShowAvailableRentalsForUser(int userId)
        {
            var rentals = _store.Rentals.Where(x => x.Borrower.Id == userId && x.RentReturnDate == null).ToList();
            var user = _store.Users.FirstOrDefault(u => u.Id == userId);
            if (rentals.Count == 0)
            {
                Console.WriteLine("Brak aktywnych wypożyczeń dla tego użytkownika.");
            }
            else
            {
                Console.WriteLine($"Aktywne wypożyczenia dla użytkownika {user.FirstName} {user.LastName}:");
                rentals.ForEach(x => Console.WriteLine(x));
                Console.WriteLine("____________________");
            }
        }
        public void ShowRentalsNotReturnedInTime()
        {
            var rentals = _store.Rentals.Where(x => x.RentReturnDate == null && x.RentReturnEndDate < DateTime.Now).ToList();
            if (rentals.Count == 0)
            {
                Console.WriteLine("Brak wypożyczeń, które nie zostały zwrócone w terminie.");
            }
            else
            {
                Console.WriteLine("Wypożyczenia, które nie zostały zwrócone w terminie:");
                rentals.ForEach(x => Console.WriteLine(x));
                Console.WriteLine("____________________");
            }
        }
    }
}
