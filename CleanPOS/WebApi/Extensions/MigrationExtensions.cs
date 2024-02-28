using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Extensions;

public static class Migrationextension
{
    public static void ApplyMigrations(this WebApplication app){
        using var scope = app.Services.CreateScope();
        var dbContext =  scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();

        dbContext.Database.Migrate();
    }
}