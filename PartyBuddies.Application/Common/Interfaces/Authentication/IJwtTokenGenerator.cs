using PartyBuddies.Domain.Entities;

namespace PartyBuddies.Application.Common.Interfaces.Authentication
{
    public interface IJwtTokenGenerator
    {
        string GenerateToken(User user);
    }
}

