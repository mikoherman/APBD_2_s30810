using Cwiczenia2.Models;
using System.Collections.Immutable;

namespace Cwiczenia2.Models;

public abstract class Hardware(Guid id, string? name, double rentalPricePerDay, Rental? currentRental = null)
{
    public Guid Id { get; set; } = id;
    public string? Name { get; init; } = name;
    public double RentalPricePerDay { get; init; } = rentalPricePerDay;
    public Rental? CurrentRental { get; set; } = currentRental;
    public bool IsAvailable => CurrentRental is null;
}

public class Laptop(string operatingSystem, int RAM, Guid id, string? name, bool isAvailable, double rentalPrice) : Hardware(id, name, isAvailable, rentalPrice)
{
    public string OperatingSystem { get; init; } = operatingSystem;
    public int RAM { get; init; } = RAM;
}
public class Projector(Guid id, string? name, bool isAvailable, double rentalPrice, string resolution = "1920x1080", string brightness = "3000 lumens") : Hardware(id, name, isAvailable, rentalPrice)
{
    public string Resolution { get; init; } = resolution;
    public string Brightness { get; init; } = brightness;
}
public class Camera(Guid id, string? name, bool isAvailable, double rentalPrice, string lensType = "Standard", string lensColor = "Standard") : Hardware(id, name, isAvailable, rentalPrice)
{
    public string LensType { get; init; } = lensType;
    public string LensColor { get; init; } = lensColor;
}
public abstract class User
{
    public Guid Id { get; set; }
    public string Name { get; init; }
    public string Surname { get; init; }
    public string UserType => this.GetType().Name;
}
public class  Employee : User
{
    
}
public class Student : User
{

}
public class Rental
{
    private double _delayFeePerDay;
    public DateTime RentalStart { get; init; }
    public DateTime? RentalEnd { get; init; }
    public double DelayFeePerDay { 
        get => _delayFeePerDay;
        set
        {
            if (value > MaxDelayFeePerDay)
                throw new InvalidOperationException($"Delay fee per day cannot exceed {MaxDelayFeePerDay}.");
            _delayFeePerDay = value;
        }
    }
    public int MaxRentalDurationInDays { get; init; }
    public User RentingUser { get; init; }
    public Hardware RentedHardware { get; init; }
    public bool IsReturnedInTime => RentalEnd.HasValue && RentalEnd.Value <= RentalStart.AddDays(MaxRentalDurationInDays);
    private const double MaxDelayFeePerDay = 200;

    public Rental(DateTime rentalStart, DateTime? rentalEnd, double delayFeePerDay, int maxRentalDurationInDays, User rentingUser, Hardware rentedHardware)
    {
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        DelayFeePerDay = delayFeePerDay;
        MaxRentalDurationInDays = maxRentalDurationInDays;
        RentingUser = rentingUser;
        RentedHardware = rentedHardware;
    }
}

public class UserRepository
{
    private readonly List<User> _users = new();
    public IEnumerable<User> GetAllUsers() => _users.ToImmutableList();
    public User? GetUserById(Guid id) => _users.FirstOrDefault(u => u.Id == id);
    public void AddUser(User user)
    {
        user.Id = Guid.NewGuid();
        _users.Add(user);
    }
}

public class HardwareRepository
{
    private readonly List<Hardware> _hardware = new();
    public void AddHardware(Hardware hardware) => _hardware.Add(hardware);
    public IEnumerable<Hardware> GetAllHardware() => _hardware.ToImmutableList();
    public string ListAllHardwareWithStatus() => $"Hardware List\n{string.Join(Environment.NewLine, _hardware.Select(h => $"{h.Id} - {h.Name} - {(h.IsAvailable ? "Available" : "Rented")}"))}";
    public string ListAllAvailableHardware() => $"Available Hardware List\n{string.Join(Environment.NewLine, _hardware.Where(h => h.IsAvailable).Select(h => $"{h.Id} - {h.Name}"))}";
}
