using Cashflow.Communication.Response;

namespace Cashflow.Application.UseCases.Expenses.GetAllExpenses;

public interface IGetAllExpensesUseCase
{
    Task<ResponseExpensesShortJson> Execute();
}