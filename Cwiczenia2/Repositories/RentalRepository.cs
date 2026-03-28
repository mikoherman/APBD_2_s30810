using Cwiczenia2.Interfaces;
using Cwiczenia2.Models;

namespace Cwiczenia2.Repositories;

public class RentalRepository : IRentalRepository
{
    private readonly IRentalFeeCalculator _rentalFeeCalculator;
    private readonly List<Rental> _rentals;

    public RentalRepository(IRentalFeeCalculator rentalFeeCalculator, List<Rental>? rentals = null)
    {
        _rentalFeeCalculator = rentalFeeCalculator;
        _rentals = new();
        rentals?.ForEach(r => AddRental(r));
    }

    public void AddRental(Rental rental)
    {
        var rentingUser = rental.RentingUser;
        if (rentingUser is null)
            throw new ArgumentException($"User in rental cannot be null: {rentingUser}");
        if (GetRentalsForUser(rentingUser.Id.Value).Count() + 1 > rentingUser.MaxActiveRentals)
            throw new InvalidOperationException($"User {rental.RentingUser.Name} {rental.RentingUser.Surname} cannot have more than {rental.RentingUser.MaxActiveRentals} active rentals.");
        if (!rental.RentedHardware.IsAvailable)
            throw new ArgumentException($"This hardware is not available for rental: {rental.RentedHardware}");
        rental.RentedHardware.CurrentRental = rental;
        _rentals.Add(rental);
    }
    public double FinishRental(Rental rental, DateTime? finishDate = null)
    {
        rental.RentalEnd = finishDate ?? DateTime.UtcNow;
        if (!RemoveRental(rental))
            throw new ArgumentException($"Something went wrong when removing rental: {rental}");
        return _rentalFeeCalculator.CalculateRentalFee(rental);
    }
    private bool RemoveRental(Rental rental)
    {
        if (_rentals.Remove(rental))
        {
            rental.RentedHardware.CurrentRental = null;
            return true;
        }
        return false;
    }
    public IEnumerable<Rental> GetRentalsForUser(Guid userId) => _rentals.Where(r => r.RentingUser.Id == userId);
    public IEnumerable<Rental> GetRentals() => _rentals;
    public IEnumerable<Rental> GetOverdueRentals() =>
        _rentals.Where(r => r.IsOverdue);
}



