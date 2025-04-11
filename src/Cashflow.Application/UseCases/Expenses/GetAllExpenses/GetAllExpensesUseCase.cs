using AutoMapper;
using Cashflow.Communication.Response;
using Cashflow.Domain.Repositories;
using Cashflow.Infra.Repositories.Expenses;

namespace Cashflow.Application.UseCases.Expenses.GetAllExpenses;

public class GetAllExpensesUseCase : IGetAllExpensesUseCase
{
    private readonly IExpensesReadOnlyRepository _repository;
    private readonly IMapper _mapper;
    public GetAllExpensesUseCase(IExpensesReadOnlyRepository repository,IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }
    public async Task<ResponseExpensesShortJson> Execute()
    {
        var result = await _repository.GetAll();
        
        return new ResponseExpensesShortJson
        {
           Expenses = _mapper.Map<List<ResponseExpenseShortJson>>(result)
        };
    }
}