﻿using DateNight.Core.Entities.IdeaAggregate;
using DateNight.Core.Interfaces;
using DateNight.Core.Services;
using DateNight.Infrastructure.Logging;
using DateNight.Infrastructure.Repositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.DependencyInjection;

namespace DateNight.Infrastructure;

public static class Dependencies
{
    public static IServiceCollection AddIdeaService(this IServiceCollection services, string connectionString)
    {
        var cosmosClientOptions = new CosmosClientOptions() { SerializerOptions = new() { PropertyNamingPolicy = CosmosPropertyNamingPolicy.CamelCase } };
        services.AddSingleton(new CosmosClient(connectionString, cosmosClientOptions));

        services.AddTransient<IRepository<Idea>, IdeaRepository>();
        services.AddTransient<IIdeaService, IdeaService>();

        return services;
    }

    public static IServiceCollection AddRequiredInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));

        return services;
    }
}