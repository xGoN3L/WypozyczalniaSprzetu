// See https://aka.ms/new-console-template for more information
using WypozyczalniaSprzetu.Data;
using WypozyczalniaSprzetu.Models.Equipments;
using WypozyczalniaSprzetu.Models.Users;
using WypozyczalniaSprzetu.Services;
namespace WypozyczalniaSprzetu
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var store = new InMemoryStore();
            UserService userService = new UserService(store);
            EquipmentService equipmentService = new EquipmentService(store);
            RentalService rentalService = new RentalService(store);
            ReportService reportService = new ReportService(store);

            var laptop = new Laptop("Dell XPS 15", "17", "Intel Core i7", true, "RTX 2070", 32);
            var laptop2 = new Laptop("MacBook Pro 16", "16", "Apple M1 Pro", true, "Apple GPU", 32);
            var camera = new Camera("Canon EOS R5", "4K", "10x", true, true);
            var projector = new Projector("Epson PowerLite", "1080p", 3000, true, true);
            var secondProjector = new Projector("Panasonic PT-RQ50K", "True 4K", 50000, true, true);

            equipmentService.AddEquipment(laptop);
            equipmentService.AddEquipment(laptop2);
            equipmentService.AddEquipment(camera);
            equipmentService.SetEquipmentAsUnavailable(camera.Id);
            equipmentService.AddEquipment(projector);
            equipmentService.AddEquipment(secondProjector);

            var user1 = new Student("Jan", "Kowalski");
            var user2 = new Employee("Anna", "Nowak");
            var user3 = new Student("Piotr", "Zieliński");
            var user4 = new Employee("Ewa", "Wiśniewska");
            var user5 = new Student("Marek", "Kowalczyk");
            var user6 = new Employee("Katarzyna", "Lewandowska");

            userService.AddUser(user1);
            userService.AddUser(user2);
            userService.AddUser(user3);
            userService.AddUser(user4);
            userService.AddUser(user5);
            userService.AddUser(user6);

            rentalService.RentEquipment(user1.Id, laptop.Id, DateTime.Now.AddDays(7), 100);
            rentalService.RentEquipment(user1.Id, camera.Id, DateTime.Now.AddDays(3), 50);
            rentalService.RentEquipment(user1.Id, projector.Id, DateTime.Now.AddDays(5), 200);
            rentalService.RentEquipment(user1.Id, laptop2.Id, DateTime.Now.AddDays(10), 150);

            var rentalToReturn = rentalService.GetRentalForEquipment(projector.Id);
            if(rentalToReturn != null)
            {
                rentalService.ReturnEquipment(rentalToReturn.Id);
            }

            var rental = rentalService.GetRentalForEquipment(laptop.Id);
            if (rental != null)
            {
                rental.RentReturnEndDate = DateTime.Now.AddDays(-1);

                rentalService.ReturnEquipment(rental.Id);
            }

            reportService.GenerateReport();

        }
    }
}

