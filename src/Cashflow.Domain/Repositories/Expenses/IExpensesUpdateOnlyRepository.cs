using Cashflow.Domain.Entities;

namespace Cashflow.Infra.Repositories.Expenses;

public interface IExpensesUpdateOnlyRepository
{
    Task<Expense?> GetById(long id);
    void Update(Expense expense);
}