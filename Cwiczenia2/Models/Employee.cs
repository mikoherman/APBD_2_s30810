namespace Cwiczenia2.Models;

public class Employee(string name, string surname, double salary, Guid? id = null) : User(name, surname, id)
{
    private const int _maxActiveRentalsForEmployee = 5;

    public override int MaxActiveRentals => _maxActiveRentalsForEmployee;

    double Salary { get; set; } = salary;
}



