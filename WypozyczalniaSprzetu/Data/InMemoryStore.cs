using System;
using WypozyczalniaSprzetu.Models;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Rentals;
using WypozyczalniaSprzetu.Models.Users;

namespace WypozyczalniaSprzetu.Data
{
    public class InMemoryStore
    {
        public List<User> Users { get; } = new List<User>();
        public List<Equipment> Equipments { get; } = new List<Equipment>();
        public List<Rental> Rentals { get; } = new List<Rental>();
    }
}