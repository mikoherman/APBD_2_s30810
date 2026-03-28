namespace Cwiczenia2.Models;

public abstract class User(string name, string surname, Guid? id = null)
{
    public Guid? Id { get; set; } = id;
    public string Name { get; init; } = name;
    public string Surname { get; init; } = surname;
    public string UserType => this.GetType().Name;
    public abstract int MaxActiveRentals { get; }

    public override string ToString() => $"{Id} - {Name}, {Surname}, {UserType}";
}
public class Student(string name, string surname, int currentSemester, Guid? id = null) : User(name, surname, id)
{
    private const int _maxActiveRentalsForStudent = 2;
    public override int MaxActiveRentals => _maxActiveRentalsForStudent;
    public int CurrentSemester { get; set; } = currentSemester;
}



