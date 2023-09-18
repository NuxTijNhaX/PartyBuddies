using PartyBuddies.Domain.Entities;

namespace PartyBuddies.Application.Services.Authentication;

public record AuthenticationResult(
    User User,
    string Token);