using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Models.Rentals
{
    public class Rental
    {
        private static int _nextId = 1;
        public int Id { get; }
        public User Borrower { get; set; }
        public Equipment EquipmentRented { get; set; }
        public DateTime RentDateStart { get; set; }
        public DateTime? RentReturnDate { get; set; }
        public bool IsReturnedInTime => DateTime.Now <= RentReturnDate;
        public decimal RentPrice { get; set; }
        public decimal? RentFine { get; set; }
        public Rental(User borrower, Equipment equipment, DateTime rentDateStart, decimal rentPrice)
        {
            Id = _nextId++;
            Borrower = borrower;
            EquipmentRented = equipment;
            RentDateStart = rentDateStart;
            RentPrice = rentPrice;
        }
    }
}
