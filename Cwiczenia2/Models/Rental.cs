namespace Cwiczenia2.Models;

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



