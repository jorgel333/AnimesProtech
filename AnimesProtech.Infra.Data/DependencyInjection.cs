﻿using AnimesProtech.Domain.Interfaces;
using AnimesProtech.Infra.Data.Context;
using AnimesProtech.Infra.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace AnimesProtech.Infra.Data;

public static class DependencyInjection
{
    public static IServiceCollection AddDataBase(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
           options.UseSqlServer(configuration.GetConnectionString("DbConnection"),
           b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName)));
        return services;
    }
    public static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IAnimeRepository, AnimeRepository>();
        return services;
    }

}
