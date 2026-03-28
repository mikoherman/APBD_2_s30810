using Cwiczenia2.Models;
using Cwiczenia2.Repositories;
using Cwiczenia2.Services;

internal class Program
{
    private static void Main(string[] args)
    {
        // inicjalizacja
        var usersList = new List<User>()
        {
            new Employee("John", "Doe", 12500, Guid.NewGuid()),
            new Student("Michael", "Jordan", 4, Guid.NewGuid()),
            new Student("Jan", "Kowalski", 8, Guid.NewGuid())
        };
        var userRepository = new UserRepository(
            usersList.ToDictionary(u => u.Id.Value, u => u)
        );
        var hardwareList = new List<Hardware>()
        {
            new Camera("Panasonic Max", 100, Guid.NewGuid()),
            new Laptop("Lenovo ThinkPad 480s", 150, "Windows 10", 8, Guid.NewGuid()),
            new Projector("Sony Standard", 200, Guid.NewGuid())
        };
        var hardwareRepository = new HardwareRepository(
            hardwareList.ToDictionary(h => h.Id.Value, h => h)
        );
        var rentalRepository = new RentalRepository(
            new RentalFeeCalculator(),
            new()
        {
            new Rental(new DateTime(2026, 3, 1), null, 30, 15, usersList[0], hardwareList[0]),
            new Rental(new DateTime(2026, 2, 12), null, 40, 7, usersList[1], hardwareList[1])
        });
        var rentalReportService = new RentalSystemReportService(rentalRepository, hardwareRepository, userRepository);
        // koniec inicjalizacji

        // Wymagania funkcjonalne
        // 1
        var user = new Employee("Krzysztof", "Nowak", 10000);
        userRepository.AddUser(user);
        // 2
        var hardware = new Camera("Sony Ericson", 125);
        hardwareRepository.AddHardware(hardware);
        // 3
        Console.WriteLine(hardwareRepository.ListAllHardwareWithStatus());
        // 4
        Console.WriteLine(hardwareRepository.ListAllAvailableHardware());
        // 5
        var rental = new Rental(new DateTime(2026, 3, 12), null, 20, 13, user, hardware);
        rentalRepository.AddRental(rental);
        // 6
        Console.WriteLine($"Zwrot sprzetu {hardware} dla {user}. Naliczona oplata: {rentalRepository.FinishRental(rental)}");
        // 7
        hardwareRepository.GetHardware(hardwareList[2].Id.Value);
        // 8
        Console.WriteLine(rentalRepository.GetRentalsForUser(user.Id.Value).ToList());
        // 9
        Console.WriteLine(rentalRepository.GetOverdueRentals().ToList());
        // 10, koncowy raport
        Console.WriteLine(rentalReportService.GenerateReport());

        // Zwrot sprzetu w terminie
        var h1 = hardwareRepository.GetAllHardware().First(h => h.IsAvailable);
        var u1 = userRepository.GetAllUsers().First();
        var r1 = new Rental(DateTime.Now.AddDays(-2), DateTime.Now, 20, 14, u1, h1);
        rentalRepository.AddRental(r1);
        Console.WriteLine($"Zwrot sprzetu {h1} dla {u1}. Naliczona oplata: {rentalRepository.FinishRental(r1)}");

        // Opozniony zwrot sprzetu, odsetki sa dodane do naliczonej oplaty
        var h2 = hardwareRepository.GetAllHardware().First(h => h.IsAvailable);
        var u2 = userRepository.GetAllUsers().First();
        var r2 = new Rental(DateTime.Now.AddDays(-20), DateTime.Now, 20, 14, u1, h1);
        rentalRepository.AddRental(r2);
        Console.WriteLine($"Zwrot sprzetu {h2} dla {u2}. Naliczona oplata: {rentalRepository.FinishRental(r2)}");

        // Proba dodania powyzej 2 wypozyczen dla studenta z limitem 2 wypozyczen.
        // Zakomentowane, bo skutkuje bledem
        //var s1 = userRepository.GetUserById(usersList[1].Id.Value);
        //rentalRepository.AddRental(new Rental(DateTime.Now, null, 20, 14, s1, hardwareRepository.GetAllHardware().First(h => h.IsAvailable)));
        //rentalRepository.AddRental(new Rental(DateTime.Now, null, 20, 14, s1, hardwareRepository.GetAllHardware().First(h => h.IsAvailable)));

        Console.ReadKey();
    }
}