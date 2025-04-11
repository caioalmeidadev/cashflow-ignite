using Cashflow.Domain.Entities;

namespace Cashflow.Infra.Repositories.Expenses;

public interface IExpensesReadOnlyRepository
{
    Task<List<Expense>> GetAll();
    
    Task<Expense?> GetById(long id);
}
