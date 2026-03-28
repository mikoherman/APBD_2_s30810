namespace Cwiczenia2.Models;

public abstract class Hardware(string name, double rentalPricePerDay, Guid? id = null, Rental? currentRental = null)
{
    public Guid? Id { get; set; } = id;
    public string Name { get; init; } = name;
    public double RentalPricePerDay { get; init; } = rentalPricePerDay;
    public Rental? CurrentRental { get; set; } = currentRental;
    public bool IsDamaged { get; set; } = false;
    public bool IsAvailable => !IsDamaged && (CurrentRental is null);
    public override string ToString() => $"{Id} - {Name}, {RentalPricePerDay}";
}
