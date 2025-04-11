using AutoMapper;
using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;
using Cashflow.Domain.Entities;

namespace Cashflow.Application.AutoMapper;

public class AutoMapping:Profile
{
    public AutoMapping()
    {
        RequestToEntity();
        EntityToResponse();
    }

    private void RequestToEntity()
    {
        CreateMap<RequestExpenseJson, Expense>();
        CreateMap<RequestRegisterUserJson, User>().ForMember(dest => dest.Password, config => config.Ignore());
    }

    private void EntityToResponse()
    {
        CreateMap<Expense, ResponseRegisteredExpenseJson>();
        CreateMap<Expense, ResponseExpensesShortJson>();
        CreateMap<Expense, ResponseExpenseShortJson>();
        CreateMap<User, ResponseRegisteredUserJson>();
    }
}