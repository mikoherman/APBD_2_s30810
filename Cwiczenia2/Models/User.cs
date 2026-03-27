namespace Cwiczenia2.Models;

public abstract class User(string name, string surname, Guid? id = null)
{
    public Guid? Id { get; set; } = id;
    public string Name { get; init; } = name;
    public string Surname { get; init; } = surname;
    public string UserType => this.GetType().Name;
    public abstract int MaxActiveRentals { get; }
}

public class Employee(string name, string surname, double salary, Guid? id = null) : User(name, surname, id)
{
    private const int _maxActiveRentalsForEmployee = 5;

    public override int MaxActiveRentals => _maxActiveRentalsForEmployee;

    double Salary { get; set; } = salary;
}
public class Student(string name, string surname, int currentSemester, Guid? id = null) : User(name, surname, id)
{
    private const int _maxActiveRentalsForStudent = 2;
    public override int MaxActiveRentals => _maxActiveRentalsForStudent;
    public int CurrentSemester { get; set; } = currentSemester;
}



