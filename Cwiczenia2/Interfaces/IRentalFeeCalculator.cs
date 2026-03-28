using Cwiczenia2.Models;

namespace Cwiczenia2.Interfaces;

public interface IRentalFeeCalculator
{
    double CalculateRentalFee(Rental rental);
}