namespace Cwiczenia2.Models;

public class Projector(string name, double rentalPrice, Guid? id = null, string resolution = "1920x1080", string brightness = "3000 lumens") : Hardware(name, rentalPrice, id)
{
    public string Resolution { get; init; } = resolution;
    public string Brightness { get; init; } = brightness;
}
