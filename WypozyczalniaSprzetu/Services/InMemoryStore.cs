using System;
using WypozyczalniaSprzetu.Models;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Users;

public class InMemoryStore
{
    public List<User> Users { get; } = new List<User>();
    public List<Equipment> Equipments { get; } = new List<Equipment>();
    public List<Rental> Rentals { get; } = new List<Rental>();
}
