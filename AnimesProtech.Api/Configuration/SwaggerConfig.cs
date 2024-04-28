using Microsoft.OpenApi.Models;

namespace AnimesProtech.Api.Configuration;

public static class SwaggerConfig
{
    public static IServiceCollection AddSwagger(this IServiceCollection services)
    {
        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Api de Gerenciamento de Animes",
                Version = "v1",
                Contact = new OpenApiContact
                {
                    Name = "Jorge Leonardo",
                    Email = "exemplodeumemailaqui@mail.com"
                }
            });

            var xmlFile = "AnimesProtech.Api.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            c.IncludeXmlComments(xmlPath);
        });

        return services;
    }
}
