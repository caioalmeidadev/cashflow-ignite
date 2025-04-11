using Cashflow.Application.AutoMapper;
using Cashflow.Application.UseCases.Expenses.GetAllExpenses;
using Cashflow.Application.UseCases.Expenses.GetByIdExpense;
using Cashflow.Application.UseCases.Expenses.Register;
using Cashflow.Application.UseCases.Login;
using Microsoft.Extensions.DependencyInjection;

namespace Cashflow.Application;

public static class DependencyInjectionExtension
{
    public static void AddApplication(this IServiceCollection services)
    {
        AddAutoMapper(services);
        AddUseCases(services);
        
    }

    private static void AddAutoMapper(IServiceCollection services)
    {
        services.AddAutoMapper(typeof(AutoMapping));
    }

    private static void AddUseCases(IServiceCollection services)
    {
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IGetAllExpensesUseCase, GetAllExpensesUseCase>();
        services.AddScoped<IGetByIdExpenseUseCase, GetByIdExpenseUseCase>();
        services.AddScoped<IRegisterExpenseUseCase, RegisterExpenseUseCase>();
        services.AddScoped<IDoLoginUseCase, DoLoginUseCase>();
    }
}