namespace Cwiczenia2.Models;

public class Rental
{
    private const double _maxDelayFeePerDay = 200;

    private double _delayFeePerDay;
    private DateTime? _rentalEnd;

    public DateTime RentalStart { get; init; }

    public DateTime? RentalEnd
    {
        get => _rentalEnd;
        set
        {
            if (value.HasValue && RentalStart > value)
                throw new InvalidOperationException("Rental End cannot be null or before rental start");

            _rentalEnd = value;
        }
    }

    public double DelayFeePerDay
    {
        get => _delayFeePerDay;
        set
        {
            if (value > _maxDelayFeePerDay)
                throw new InvalidOperationException($"Delay fee per day cannot exceed {_maxDelayFeePerDay}.");

            _delayFeePerDay = value;
        }
    }

    public int MaxRentalDurationInDays { get; init; }

    public User RentingUser { get; init; }

    public Hardware RentedHardware { get; init; }

    public bool IsReturnedInTime =>
        RentalEnd.HasValue &&
        RentalEnd.Value <= RentalStart.AddDays(MaxRentalDurationInDays);
    public bool IsOverdue =>
        !RentalEnd.HasValue &&
        DateTime.Now > RentalStart.AddDays(MaxRentalDurationInDays);

    public Rental(
        DateTime rentalStart,
        DateTime? rentalEnd,
        double delayFeePerDay,
        int maxRentalDurationInDays,
        User rentingUser,
        Hardware rentedHardware)
    {
        RentalStart = rentalStart;
        RentalEnd = rentalEnd;
        DelayFeePerDay = delayFeePerDay;
        MaxRentalDurationInDays = maxRentalDurationInDays;
        RentingUser = rentingUser;
        RentedHardware = rentedHardware;
    }

}