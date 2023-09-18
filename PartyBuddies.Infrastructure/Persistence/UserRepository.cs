using PartyBuddies.Application.Common.Interfaces.Persistence;
using PartyBuddies.Domain.Entities;

namespace PartyBuddies.Infrastructure.Persistence;

public class UserRepository : IUserRepository
{
    private static readonly List<User> _user = new();

    public void AddUser(User user)
    {
        _user.Add(user);
    }

    public User? GetUserByEmail(string email)
    {
        return _user.SingleOrDefault(user => user.Email == email);
    }
}