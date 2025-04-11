namespace Cashflow.Application.UseCases.Expenses.DeleteExpense;

public interface IDeleteExpenseUseCase
{
    Task Execute(long id);
}