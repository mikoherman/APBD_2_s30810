using Cwiczenia2.Interfaces;
using Cwiczenia2.Models;

namespace Cwiczenia2.Services;

public class RentalFeeCalculator : IRentalFeeCalculator
{
    public double CalculateRentalFee(Rental rental)
    {
        if (rental.RentalEnd is null)
            throw new InvalidOperationException($"Rental is not finished: {rental}");
        int rentalDurationInFullDays = (int)((TimeSpan)(rental.RentalEnd - rental.RentalStart)).TotalDays;
        double fee = rentalDurationInFullDays * rental.RentedHardware.RentalPricePerDay;
        fee += rental.IsReturnedInTime ? 0 : (rentalDurationInFullDays - rental.MaxRentalDurationInDays) * rental.DelayFeePerDay;
        return fee;
    }
}
