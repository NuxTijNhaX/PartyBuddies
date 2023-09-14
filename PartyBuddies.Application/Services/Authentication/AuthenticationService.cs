using PartyBuddies.Application.Common.Interfaces.Authentication;
using PartyBuddies.Application.Common.Interfaces.Persistence;
using PartyBuddies.Domain.Entities;

namespace PartyBuddies.Application.Services.Authentication;

public class AuthenticationService : IAuthenticationService
{
    private readonly IJwtTokenGenerator _jwtTokenGenerator;
    private readonly IUserRepository _userRepository;

    public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        _jwtTokenGenerator = jwtTokenGenerator;
        _userRepository = userRepository;
    }

    public AuthenticationResult Login(string email, string password)
    {
        if (_userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email already exists.");
        }


        return new AuthenticationResult(
            Guid.NewGuid(),
            "FirstName",
            "LastName",
            email,
            "Token");
    }

    public AuthenticationResult Register(
        string firstName,
        string lastName,
        string email,
        string password)
    {
        if (_userRepository.GetUserByEmail(email) is not null)
        {
            throw new Exception("User with given email already exists.");
        }

        var newUser = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            Password = password
        };

        _userRepository.AddUser(newUser);

        var token = _jwtTokenGenerator.GenerateToken(newUser.Id, firstName, lastName);

        return new AuthenticationResult(
            newUser.Id,
            firstName,
            lastName,
            email,
            token);
    }
}
