using Cashflow.Communication.Requests;
using Cashflow.Communication.Response;

namespace Cashflow.Application.UseCases.User.Register;

public interface IRegisterUserUseCase
{
    Task<ResponseRegisteredUserJson> Execute(RequestRegisterUserJson request);
}