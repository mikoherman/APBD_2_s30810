using Cwiczenia2.Models;

namespace Cwiczenia2.Interfaces;

public interface IRentalRepository
{
    void AddRental(Rental rental);
    double FinishRental(Rental rental, DateTime? finishDate = null);
    IEnumerable<Rental> GetRentals();
    IEnumerable<Rental> GetRentalsForUser(Guid userId);
    IEnumerable<Rental> GetOverdueRentals();
}



