using System.Collections.Immutable;
using Cwiczenia2.Interfaces;
using Cwiczenia2.Models;

namespace Cwiczenia2.Repositories;

public class UserRepository(Dictionary<Guid, User>? users = null) : IUserRepository
{
    private readonly Dictionary<Guid, User> _users = users ?? new();
    public IEnumerable<User> GetAllUsers() => _users.Values.ToImmutableList();
    public User? GetUserById(Guid id) => _users.GetValueOrDefault(id);
    public void AddUser(User user)
    {
        user.Id = Guid.NewGuid();
        _users[user.Id.Value] = user;
    }
}

