using Cashflow.Domain.Entities;

namespace Cashflow.Domain.Repositories;

public interface IExpensesRepository
{
    void Add(Expense expense);
}