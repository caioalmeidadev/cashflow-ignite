using Cashflow.Application.UseCases.Expenses.Register;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
    }
}