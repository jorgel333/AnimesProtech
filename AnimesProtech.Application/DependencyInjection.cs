using AnimesProtech.Application.Behaviours;
using AnimesProtech.Application.Features.Animes.GetAllFilter;
using AnimesProtech.Application.Features.Animes.Register;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace AnimesProtech.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining(typeof(RegisterAnimeCommand));
        services.AddMediatR(config =>
        {
            config.RegisterServicesFromAssemblyContaining<GetAllFilterAnimesQuery>();
            config.AddOpenBehavior(typeof(ValidationHandlingBehaviour<,>));
        });

        return services;
    }
}
