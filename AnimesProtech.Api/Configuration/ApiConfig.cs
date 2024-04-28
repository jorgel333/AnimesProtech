using AnimesProtech.Application;
using AnimesProtech.Infra.IoC;

namespace AnimesProtech.Api.Configuration;

public static class ApiConfig
{
    public static IServiceCollection AddApiConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddInfrastructure(configuration);
        services.AddApplication();
        return services;
    }
}
