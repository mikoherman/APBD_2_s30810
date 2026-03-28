namespace Cwiczenia2.Models;

public class Camera(string name, double rentalPrice, Guid? id = null, string lensType = "Standard", string lensColor = "Standard") : Hardware(name, rentalPrice, id)
{
    public string LensType { get; init; } = lensType;
    public string LensColor { get; init; } = lensColor;
}