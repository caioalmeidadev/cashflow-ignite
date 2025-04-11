using Cashflow.Domain.Repositories;
using Cashflow.Domain.Repositories.User;
using Cashflow.Domain.Security.Cryptography;
using Cashflow.Domain.Security.Tokens;
using Cashflow.Infra.DataAccess;
using Cashflow.Infra.Repositories;
using Cashflow.Infra.Repositories.Expenses;
using Cashflow.Infra.Security.Tokens;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Infra;

public static class DependecyInjectionExtensions
{
    public static void AddInfra(this IServiceCollection services, IConfiguration configuration)
    {
        AddDbContext(services,configuration);
        AddRepositories(services);
        AddToken(services, configuration);
    }

    private static void AddToken(IServiceCollection services, IConfiguration configuration)
    {
        var expirationInMinutes = configuration.GetValue<uint>("Settings:JWT:TokenExpirationInMinutes");
        var signInKey = configuration.GetValue<string>("Settings:JWT:SigningKey");
        services.AddScoped<IAccessTokenGenerator>(options => new JwtTokenGenerator(expirationInMinutes, signInKey!));
    }
    private static void AddRepositories(IServiceCollection services)
    {
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IPassowordEncripter, Security.Cryptography.BCrypt>();
        services.AddScoped<IExpensesWriteOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesReadOnlyRepository, ExpensesRepository>();
        services.AddScoped<IExpensesUpdateOnlyRepository, ExpensesRepository>();
        services.AddScoped<IUserReadOnlyRepository, UserRepository>();
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        var serverVersion = new MySqlServerVersion(new Version(8, 0, 21));
        
        services.AddDbContext<CashflowDBContext>(config => config.UseMySql(connectionString,serverVersion)); 
    }
}