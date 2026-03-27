using Cwiczenia2.Models;

internal class Program
{
    private static void Main(string[] args)
    {
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
        var rentalRepository = new RentalRepository(new()
        {
            new Rental()
        });
    }
}