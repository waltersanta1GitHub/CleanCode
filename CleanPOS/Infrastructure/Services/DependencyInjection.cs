using Application.Data;
using Domain.Customers;
using Domain.Primitives;
using Infrastructure.Persistence;
using Infrastructure.Persistence.Repostories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration){
        services.AddPersitence(configuration);
        return services;

    }

    public static IServiceCollection AddPersitence(this IServiceCollection services, IConfiguration configuration){
        
        services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(configuration.GetConnectionString("Database")));
        
        services.AddScoped<IApplicationDbContext>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IUnitOfWork>(sp => 
            sp.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<ICustomerRepository, CustomerRepository>();

        return services;
    }
}