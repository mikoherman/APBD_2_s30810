namespace Cwiczenia2.Models;

public class Laptop(string name, double rentalPrice, string operatingSystem, int RAM, Guid? id = null) : Hardware(name, rentalPrice, id)
{
    public string OperatingSystem { get; init; } = operatingSystem;
    public int RAM { get; init; } = RAM;
}
