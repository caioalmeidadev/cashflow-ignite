using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Exception.ExceptionBase;

namespace Cashflow.Application.UseCases.Expenses.Register;

public class RegisterExpenseUseCase : IRegisterExpenseUseCase
{
    private readonly IExpensesRepository _expensesRepository;
    private readonly IUnitOfWork _unitOfWork;
    public RegisterExpenseUseCase(IExpensesRepository repository,IUnitOfWork unitOfWork)
    {
        _expensesRepository = repository;
        _unitOfWork = unitOfWork;
    }
    public ResponseRegisteredExpenseJson Execute(ResquestRegisterExpenseJson request)
    {
       Validate(request);

       var entity = new Expense
       {
           Amount = request.Amount,
           Description = request.Description,
           Title = request.Title,
           PaymentType = (Domain.Enums.PaymentType)request.PaymentType
       };
       
       _expensesRepository.Add(entity);
       _unitOfWork.Commit();
       
       return new ResponseRegisteredExpenseJson{Title = request.Title}; 
    }

    private void Validate(ResquestRegisterExpenseJson request)
    {
        var validator = new RegisterExpensesValidator();
        var result = validator.Validate(request);
        if (!result.IsValid)
        {
            var errors = result.Errors.Select(x => x.ErrorMessage).ToList();
            
            throw new ErrorOnValidationException(errors);
        }
        
        
    }
}