using AutoMapper;
using Cashflow.Communication.Response;
using Cashflow.Exception.ExceptionBase;
using Cashflow.Infra.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.GetByIdExpense;

public class GetByIdExpenseUseCase:IGetByIdExpenseUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetByIdExpenseUseCase(IExpensesReadOnlyRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    
    public async Task<ResponseExpenseShortJson> Execute(long id)
    {
        var result = await _repository.GetById(id);
        if (result is null)
            throw new NotFoundException("Expense not found");
        return _mapper.Map<ResponseExpenseShortJson>(result);
    }
}