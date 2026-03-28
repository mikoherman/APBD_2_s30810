using System.Collections.Immutable;
using Cwiczenia2.Interfaces;
using Cwiczenia2.Models;

namespace Cwiczenia2.Repositories;

public class HardwareRepository(Dictionary<Guid, Hardware>? hardware = null) : IHardwareRepository
{
    private readonly Dictionary<Guid, Hardware> _hardware = hardware ?? new();
    public void AddHardware(Hardware hardware)
    {
        hardware.Id = Guid.NewGuid();
        _hardware[hardware.Id.Value] = hardware;
    }
    public Hardware GetHardware(Guid hardwareId) => _hardware[hardwareId];
    public IEnumerable<Hardware> GetAllHardware() => _hardware.Values.ToImmutableList();
    public string ListAllHardwareWithStatus() => $"Hardware List\n{string.Join(Environment.NewLine, _hardware.Values.Select(h => $"{h.Id} - {h.Name} - {(h.IsAvailable ? "Available" : "Rented")}"))}";
    public string ListAllAvailableHardware() => $"Available Hardware List\n{string.Join(Environment.NewLine, _hardware.Values.Where(h => h.IsAvailable).Select(h => $"{h.Id} - {h.Name}"))}";

    public IEnumerable<Hardware> GetAllDamagedHardware() => _hardware.Values.Where(h => h.IsDamaged);
}

