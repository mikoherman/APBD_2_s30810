using Cwiczenia2.Interfaces;

namespace Cwiczenia2.Services;

public class RentalSystemReportService(IRentalRepository rentalRepository, IHardwareRepository hardwareRepository, IUserRepository userRepository) : IRentalSystemReportService
{
    private readonly IRentalRepository _rentalRepository = rentalRepository;
    private readonly IHardwareRepository _hardwareRepository = hardwareRepository;
    private readonly IUserRepository _userRepository = userRepository;

    public string GenerateReport() =>
        $"Rental State for date - {DateTime.Now}\nNumber of active rentals: {_rentalRepository.GetRentals().Count()}\nNumber of overdue rentals: {_rentalRepository.GetOverdueRentals().Count()}\nCurrently registered users: {_userRepository.GetAllUsers().Count()}\nNumber of all hardware: {_hardwareRepository.GetAllHardware().Count()}\nNumber of damaged hardware: {_hardwareRepository.GetAllDamagedHardware().Count()}";
}
