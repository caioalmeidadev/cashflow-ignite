using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Exception.ExceptionBase;
using Cashflow.Infra.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesWriteOnlyRepository _expensesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterExpenseUseCase(IExpensesWriteOnlyRepository repository,IUnitOfWork unitOfWork)
    {
        _expensesRepository = repository;
        _unitOfWork = unitOfWork;
    }
    public async Task<ResponseRegisteredExpenseJson> Execute(RequestExpenseJson request)
    {
       Validate(request);

       var entity = new Expense
       {
           Amount = request.Amount,
           Description = request.Description,
           Title = request.Title,
           PaymentType = (Domain.Enums.PaymentType)request.PaymentType
       };
       
       await _expensesRepository.Add(entity);
       await _unitOfWork.Commit();
       
       return new ResponseRegisteredExpenseJson{Title = request.Title}; 
    }

    private void Validate(RequestExpenseJson request)
    {
        var validator = new ExpensesValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errors);
        }
        
        
    }
}