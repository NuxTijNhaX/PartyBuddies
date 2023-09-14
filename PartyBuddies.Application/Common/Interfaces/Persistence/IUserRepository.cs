using PartyBuddies.Domain.Entities;

namespace PartyBuddies.Application.Common.Interfaces.Persistence;

public interface IUserRepository
{
    User? GetUserByEmail(string email);
    void AddUser(User user);
}