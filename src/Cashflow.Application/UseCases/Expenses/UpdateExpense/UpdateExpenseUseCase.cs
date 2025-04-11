using AutoMapper;
using Cashflow.Application.UseCases.Expenses.Register;
using Cashflow.Communication.Requests;
using Cashflow.Domain.Entities;
using Cashflow.Domain.Repositories;
using Cashflow.Exception.ExceptionBase;
using Cashflow.Infra.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.UpdateExpense;

public class UpdateExpenseUseCase:IUpdateExpenseUseCase
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IExpensesUpdateOnlyRepository _repository;

    public UpdateExpenseUseCase(IMapper mapper, IUnitOfWork unitOfWork, IExpensesUpdateOnlyRepository repository)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
        _repository = repository;
    }
    
    public async Task Execute(long id, RequestExpenseJson request)
    {
       Validate(request);

       var expense = await _repository.GetById(id);

       if (expense is null)
       {
           throw new NotFoundException("Expense not found");
       }
       _mapper.Map(request, expense);
       
       _repository.Update(expense);
       
       await _unitOfWork.Commit();
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