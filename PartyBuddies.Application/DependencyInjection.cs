using Microsoft.Extensions.DependencyInjection;
using PartyBuddies.Application.Services.Authentication;

namespace PartyBuddies.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthenticationService, AuthenticationService>();

        return services;
    }
}