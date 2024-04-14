using System.Reflection;
using CallForPapers.Contracts.Repositories;
using CallForPapers.DAL.Database;
using CallForPapers.DAL.Repositories;
using CallForPapers.Infrastructure.Behavior;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CallForPapers.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, ConfigurationManager config)
    {
        services
            .AddRepositories()
            .AddMediatR(x =>
                x.RegisterServicesFromAssemblies(Assembly.Load("CallForPapers.Application")))
            .AddValidators()
            .AddSwaggerGen()
            .AddDbContext<DatabaseContext>(opt =>
                opt.UseNpgsql(config["ConnectionStrings:URI"],
                    v => v.MigrationsAssembly("CallForPapers.Migrations"))
            )
            .AddControllers();
        
        return services;
    }

    private static IServiceCollection AddRepositories(this IServiceCollection services)
    {
        services
            .AddTransient<IStatementRepository, StatementRepository>()
            .AddTransient<IStatementActivityRepository, StatementActivityRepository>();

        return services;
    }

    private static IServiceCollection AddValidators(this IServiceCollection services)
    {
        services
            .AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>))
            .AddValidatorsFromAssemblies(AppDomain.CurrentDomain.GetAssemblies());

        return services;
    }
}