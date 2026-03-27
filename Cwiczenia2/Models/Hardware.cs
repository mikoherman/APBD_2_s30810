namespace Cwiczenia2.Models;

public abstract class Hardware(string name, double rentalPricePerDay, Guid? id = null, Rental? currentRental = null)
{
    public Guid? Id { get; set; } = id;
    public string Name { get; init; } = name;
    public double RentalPricePerDay { get; init; } = rentalPricePerDay;
    public Rental? CurrentRental { get; set; } = currentRental;
    public bool IsAvailable => CurrentRental is null;
}

public class Laptop(string name, double rentalPrice, string operatingSystem, int RAM, Guid? id = null) : Hardware(name, rentalPrice, id)
{
    public string OperatingSystem { get; init; } = operatingSystem;
    public int RAM { get; init; } = RAM;
}
public class Projector(string name, double rentalPrice, Guid? id = null, string resolution = "1920x1080", string brightness = "3000 lumens") : Hardware(name, rentalPrice, id)
{
    public string Resolution { get; init; } = resolution;
    public string Brightness { get; init; } = brightness;
}
public class Camera(string name, double rentalPrice, Guid? id = null, string lensType = "Standard", string lensColor = "Standard") : Hardware(name, rentalPrice, id)
{
    public string LensType { get; init; } = lensType;
    public string LensColor { get; init; } = lensColor;
}