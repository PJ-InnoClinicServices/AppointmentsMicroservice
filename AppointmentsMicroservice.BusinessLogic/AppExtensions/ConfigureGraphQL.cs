﻿using BusinessLogicLayer.Schema.Mutations;
using BusinessLogicLayer.Schema.Queries;
using DataAccessLayer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLogicLayer.AppExtensions;

public class ConfigureGraphQl(IConfiguration configuration)
{
    public void Configure(IServiceCollection services)
    { 
        services.AddGraphQLServer()
            .AddQueryType<Query>()
            .AddMutationType<Mutation>()
            .AddDiagnosticEventListener<ErrorLoggingDiagnosticsEventListener>();
            
        services.AddPooledDbContextFactory<ApplicationDbContext>(options => 
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
    }
        
    public static void ApplyMigrations(IServiceProvider serviceProvider)
    {
        using var scope = serviceProvider.CreateScope();

        var dbContextFactory = scope.ServiceProvider.GetRequiredService<IDbContextFactory<ApplicationDbContext>>();
        var dbContext = dbContextFactory.CreateDbContext(); 

        dbContext.Database.Migrate(); 
    }
}