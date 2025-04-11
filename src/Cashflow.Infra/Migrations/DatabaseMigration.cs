using Cashflow.Infra.DataAccess;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Infra.Migration;

public static class DatabaseMigration
{
    public static async Task MigrateDatabase(IServiceProvider serviceProvider)
    { 
        var dbContext = serviceProvider.GetRequiredService<CashflowDBContext>();

        await dbContext.Database.MigrateAsync();
    }
}