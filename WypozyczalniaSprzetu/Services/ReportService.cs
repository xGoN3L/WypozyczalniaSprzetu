using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Data;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Services
{
    public class ReportService
    {
        private readonly InMemoryStore _store;
        public ReportService(InMemoryStore store)
        {
            _store = store;
        }
        public void GenerateReport()
        {
            int totalRentals = _store.Rentals.Count;
            int totalReturnedRentals = _store.Rentals.Count(r => r.RentReturnDate != null);
            int totalNotReturnedRentals = totalRentals - totalReturnedRentals;
            int totalEquipment = _store.Equipments.Count;
            int totalAvailableEquipment = _store.Equipments.Count(x => x.Status == EquipmentStatus.Available);
            int totalUnavailableEquipment = _store.Equipments.Count(x => x.Status == EquipmentStatus.Unvailable);
            int totalBorrowedEquipment = _store.Equipments.Count(x => x.Status == EquipmentStatus.Borrowed);
            int totalStudentUsers = _store.Users.Count(x => x.UserType == UserType.Student);
            int totalEmployeeUsers = _store.Users.Count(x => x.UserType == UserType.Employee);

            Console.WriteLine("Raport:");
            Console.WriteLine($"Wszystkie wypożyczenia: {totalRentals}");
            Console.WriteLine($"Wszystkie zwrócone wypożyczenia: {totalReturnedRentals}");
            Console.WriteLine($"Wszystkie niezwrócone wypożyczenia: {totalNotReturnedRentals}");
            Console.WriteLine($"Liczba sprzętu: {totalEquipment}");
            Console.WriteLine($"Liczba dostępnego sprzętu: {totalAvailableEquipment}");
            Console.WriteLine($"Liczba wypożyczonego sprzętu: {totalBorrowedEquipment}");
            Console.WriteLine($"Liczba niedostępnego sprzętu: {totalUnavailableEquipment}");
            Console.WriteLine($"Liczba użytkowników typu student: {totalStudentUsers}");
            Console.WriteLine($"Liczba użytkowników typu pracownik: {totalEmployeeUsers}");
            Console.WriteLine($"\n");
        }
    }
}
