using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Models
{
    public class Rental
    {
        public int Id { get; }
        public User Borrower { get; set; }
        public Equipment EquipmentRented { get; set; }
        public DateTime RentDateStart { get; set; }
        public DateTime RentReturnDate { get; set; }
        public bool IsReturnedInTime => DateTime.Now <= RentReturnDate;
        public decimal RentPrice { get; set; }
        public decimal? RentFine { get; set; }

    }
}
