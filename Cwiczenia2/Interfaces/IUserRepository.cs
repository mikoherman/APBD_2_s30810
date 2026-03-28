using Cwiczenia2.Models;

namespace Cwiczenia2.Interfaces;

public interface IUserRepository
{
    void AddUser(User user);
    IEnumerable<User> GetAllUsers();
    User? GetUserById(Guid id);
}

