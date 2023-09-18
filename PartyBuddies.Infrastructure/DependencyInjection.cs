using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PartyBuddies.Application.Common.Interfaces.Authentication;
using PartyBuddies.Application.Common.Interfaces.Persistence;
using PartyBuddies.Application.Common.Interfaces.Services;
using PartyBuddies.Infrastructure.Authentication;
using PartyBuddies.Infrastructure.Persistence;

namespace PartyBuddies.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
       ConfigurationManager configuration)
    {
        services.Configure<JwtTokenSettings>(configuration.GetSection(JwtTokenSettings.SectionName));

        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}