using Cwiczenia2.Models;

namespace Cwiczenia2.Interfaces;

public interface IHardwareRepository
{
    void AddHardware(Hardware hardware);
    Hardware GetHardware(Guid hardwareId);
    IEnumerable<Hardware> GetAllHardware();
    IEnumerable<Hardware> GetAllDamagedHardware();
    string ListAllAvailableHardware();
    string ListAllHardwareWithStatus();
}

