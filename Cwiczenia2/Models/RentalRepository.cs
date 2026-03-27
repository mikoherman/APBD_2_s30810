namespace Cwiczenia2.Models;

public class RentalRepository(List<Rental>? rentals = null) : IRentalRepository
{
    private readonly List<Rental> _rentals = rentals ?? new();
    public void AddRental(Rental rental)
    {
        var rentingUser = rental.RentingUser;
        if (rentingUser is null)
            throw new ArgumentException("User in rental cannot be null");
        if (GetRentalsForUser(rentingUser.Id.Value).Count() + 1 > rentingUser.MaxActiveRentals)
            throw new InvalidOperationException($"User {rental.RentingUser.Name} {rental.RentingUser.Surname} cannot have more than {rental.RentingUser.MaxActiveRentals} active rentals.");
        rental.RentedHardware.CurrentRental = rental;
        _rentals.Add(rental);
    }
    public bool RemoveRental(Rental rental){
       if (_rentals.Remove(rental))
        {
            rental.RentedHardware.CurrentRental = null;
            return true;
        }
        return false;
    }
    public IEnumerable<Rental> GetRentalsForUser(Guid userId) => _rentals.Where(r => r.RentingUser.Id == userId);
    public IEnumerable<Rental> GetRentals(Guid userId) => _rentals.Where(r => r.RentingUser.Id == userId);
}

public interface IRentalRepository
{
    void AddRental(Rental rental);
    IEnumerable<Rental> GetRentals(Guid userId);
    IEnumerable<Rental> GetRentalsForUser(Guid userId);
    bool RemoveRental(Rental rental);
}



