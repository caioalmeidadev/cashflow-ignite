using Cashflow.Domain.Repositories;
using Cashflow.Exception.ExceptionBase;
using Cashflow.Infra.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.DeleteExpense;

public class DeleteExpenseUseCase:IDeleteExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _repository;
    private readonly IUnitOfWork _unitOfWork;
 
    public DeleteExpenseUseCase(
        IExpensesWriteOnlyRepository repository,
        IUnitOfWork unitOfWork)
    {
        _repository = repository;
        _unitOfWork = unitOfWork;
    }
 
    public async Task Execute(long id)
    {
        var result = await _repository.Delete(id);
 
        if (result == false)
        {
            throw new NotFoundException("Expense not found");
        }
 
        await _unitOfWork.Commit();
    }
    
}